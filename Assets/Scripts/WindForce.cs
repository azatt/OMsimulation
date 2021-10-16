using UnityEngine;

public class WindForce : MonoBehaviour
{
    Rigidbody rigidbody;
    TimeMultipier timeM;
    GameObject timeObject, windDirection;

    void Start()
    {
        timeObject = GameObject.FindWithTag("time");
        windDirection = GameObject.FindWithTag("wind");
        
        rigidbody = gameObject.GetComponent<Rigidbody>();
        timeM = timeObject.GetComponent<TimeMultipier>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(windDirection.transform.forward * (13 * timeM.timeMultipier * timeM.timeMultipier), ForceMode.Impulse);
    }
}
