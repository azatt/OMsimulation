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
        if (Vector3.Distance(targetPosition, transform.position) < 0.1)
        {
            new Vector3(planeRange * Random.value, transform.position.y, planeRange * Random.value);
        }
        Vector3.MoveTowards(transform.position, targetPosition, translate);
        Debug.Log(targetPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I found a tumbleweed!");
    }
}
