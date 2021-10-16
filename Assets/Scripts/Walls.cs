using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "tumbleweed")
        {
            SimplePool.Despawn(collider.gameObject);
        }
    }
}
