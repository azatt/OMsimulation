using UnityEngine;

public class LifespanHuman : MonoBehaviour
{
    TimeMultipier timeM;
    public GameObject timeObject;
    public int timeToDie    = 85000;
    public float walkSpeed  = 50;
    public int planeRange   = 100;
    public int workingHours = 2;
    // timeToDie = 85000 (about 10 years)
    // walkSpeed = 50 (1 unit of distance is 10 meters. A human walks about 5 km/h, thus a speed of 50)
    // planeRange = the size of the field (100x100)
    // workingHours = 2 (every human on tumbleweed-search-duty has to search for 2 hours a day for tumbleweeds)
    
    private float translate;
    private Vector3 targetPosition;
    private bool foundTumbleweed;
    private GameObject foundTumbleweedObject;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timeObject = GameObject.FindWithTag("time");
        timeM = timeObject.GetComponent<TimeMultipier>();
        targetPosition = new Vector3(planeRange * Random.value, 1, planeRange * Random.value);
        foundTumbleweed = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < workingHours)
        {
            if (!foundTumbleweed) { WalkAround(); }
            else { KillTumbleweed(); }
        }
        timer += timeM.timeMultipier * Time.deltaTime;
        if (timer >= 24) { timer = 0; }
    }

    void WalkAround()
    {
        translate = timeM.timeMultipier * walkSpeed * Time.deltaTime;
        if (Vector3.Distance(targetPosition, transform.position) < 1)
        {
            targetPosition = new Vector3(planeRange * Random.value, 1, planeRange * Random.value);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, translate);
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("tumbleweed"))
        {
            //Debug.Log("I found a tumbleweed!");
            foundTumbleweed = true;
            foundTumbleweedObject = collider.gameObject;
        }
    }
    
    private void KillTumbleweed()
    {
        if (!foundTumbleweedObject.activeSelf)
        {
            foundTumbleweed = false;
            return;
        }
        if (Vector3.Distance(foundTumbleweedObject.transform.position, transform.position) < 1)
        {
            SimplePool.Despawn(foundTumbleweedObject);
            foundTumbleweed = false;
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, foundTumbleweedObject.transform.position, translate);
    }
}
