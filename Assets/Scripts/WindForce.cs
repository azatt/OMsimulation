using UnityEngine;
using System.Collections;

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
        
        StartCoroutine(Blow());
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    rigidbody.AddForce(windDirection.transform.forward * (13 * timeM.timeMultipier), ForceMode.Impulse);
    //}

    IEnumerator Blow()
    {
        for (;;)
        {
            rigidbody.velocity = windDirection.transform.forward * (13f * timeM.timeMultipier);
            //rigidbody.AddForce(windDirection.transform.forward * (13 * timeM.timeMultipier * timeM.timeMultipier), ForceMode.Impulse);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
