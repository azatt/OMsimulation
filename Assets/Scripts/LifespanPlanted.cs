using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifespanPlanted : MonoBehaviour
{
    public GameObject prefab;
    TimeMultipier timeM;
    public GameObject timeObject;
    public int timeToGrow, timeToDie;
    public bool seed;
    
    // Start is called before the first frame update
    void Start()
    {
        timeObject = GameObject.FindWithTag("time");
        timeM = timeObject.GetComponent<TimeMultipier>();
        seed = true;
        
        StartCoroutine(Grow());
        StartCoroutine(Wait());
    }

    IEnumerator Grow()
    {
        yield return new WaitForSeconds(timeToGrow / timeM.timeMultipier);
        gameObject.transform.localScale += new Vector3(0.9f, 0.9f, 0.9f);
        seed = false;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds((timeToDie + timeToGrow) / timeM.timeMultipier);
        SimplePool.Spawn(prefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
