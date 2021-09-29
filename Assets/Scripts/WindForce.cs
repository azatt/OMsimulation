using UnityEngine;

public class WindForce : MonoBehaviour
{
    Rigidbody rigidbody;
    public GameObject windDirection;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.AddForce(windDirection.transform.forward * 10);
    }
}
