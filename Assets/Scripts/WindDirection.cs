using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class WindDirection : MonoBehaviour
{
    public GameObject timeObject;
    TimeMultipier timeM;

    void Start()
    {
        timeM = timeObject.GetComponent<TimeMultipier>();
        RandomWindDir();
        StartCoroutine("ChangeWindDir");
    }

    IEnumerator ChangeWindDir()
    {
        for (; ; )
        {
            //transform.Rotate(0, 0.3f * timeM.timeMultipier, 0);
            //yield return new WaitForSeconds(0.02f);
            float random = Random.Range(20f, 168f);
            RandomWindDir();
            yield return new WaitForSeconds(random);
        }
    }


    void RandomWindDir()
    {
        var tempRotation = Quaternion.identity;
        var tempVector = Vector3.zero;
        tempVector = tempRotation.eulerAngles;
        tempVector.y = Random.Range(0, 359);
        tempRotation.eulerAngles = tempVector;
        transform.rotation = tempRotation;
    }
}
