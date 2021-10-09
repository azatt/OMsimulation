using UnityEngine;

public class LifespanHuman : MonoBehaviour
{
    TimeMultipier timeM;
    public GameObject timeObject;
    public int timeToDie;
    public float walkSpeed = 0.1f;
    public int planeRange = 100;
    private float translate;
    private Vector3 targetPosition;

    private bool foundTumbleweed;
    private GameObject foundTumbleweedObject;

    // Start is called before the first frame update
    void Start()
    {
        timeObject = GameObject.FindWithTag("time");
        timeM = timeObject.GetComponent<TimeMultipier>();
        targetPosition = new Vector3(planeRange * Random.value, transform.position.y, planeRange * Random.value);
        foundTumbleweed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!foundTumbleweed) { WalkAround(); }
        else { KillTumbleweed(); }
    }

    void WalkAround()
    {
        translate = timeM.timeMultipier * walkSpeed * Time.deltaTime;
        if (Vector3.Distance(targetPosition, transform.position) < 1)
        {
            targetPosition = new Vector3(planeRange * Random.value, transform.position.y, planeRange * Random.value);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, translate);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "tumbleweed")
        {
            Debug.Log("I found a tumbleweed!");
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
