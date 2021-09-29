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

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ChangeWindDir()
    {
        for (; ; )
        {
            RandomWindDir();
            Debug.Log("Current direction: " + transform.rotation.ToString());
            yield return new WaitForSeconds(1 * 1 / timeM.timeMultipier);
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
