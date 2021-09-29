using UnityEngine;

public class WindForce : MonoBehaviour
{
    Rigidbody rigidbody;
    public GameObject windDirection;
    TimeMultipier timeM;
    public GameObject timeObject;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        timeM = timeObject.GetComponent<TimeMultipier>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(windDirection.transform.forward * 10 * timeM.timeMultipier);
    }
}
