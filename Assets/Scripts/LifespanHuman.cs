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

    // Start is called before the first frame update
    void Start()
    {
        timeObject = GameObject.FindWithTag("time");
        timeM = timeObject.GetComponent<TimeMultipier>();
        targetPosition = new Vector3(planeRange * Random.value, transform.position.y, planeRange * Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        WalkAround();

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
        }
    }
    private void KillTumbleweed()
    {

    }
}
