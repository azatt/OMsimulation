using System.Collections;
using UnityEngine;

public class WindDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
            yield return new WaitForSeconds(1);
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
