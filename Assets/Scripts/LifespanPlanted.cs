using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifespanPlanted : MonoBehaviour
{
    public GameObject prefab;
    TimeMultipier timeM;
    public GameObject timeObject;
    public int timeToGrow;
    
    // Start is called before the first frame update
    void Start()
    {
        timeM = timeObject.GetComponent<TimeMultipier>();
        StartCoroutine(Wait());
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeToGrow * 1 / timeM.timeMultipier);
        SimplePool.Spawn(prefab, transform.position, transform.rotation);
    }
}
