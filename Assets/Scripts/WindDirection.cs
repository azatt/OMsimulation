using System.Collections;
using UnityEngine;

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
            transform.Rotate(0, 0.25f, 0);
            Debug.Log("Current direction: " + transform.rotation.ToString());
            yield return new WaitForSeconds(1 / timeM.timeMultipier);
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
