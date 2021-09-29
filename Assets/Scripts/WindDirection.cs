using UnityEngine;

public class WindDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var tempRotation = Quaternion.identity;
        var tempVector = Vector3.zero;
        tempVector = tempRotation.eulerAngles;
        tempVector.y = Random.Range(0, 359);
        tempRotation.eulerAngles = tempVector;
        transform.rotation = tempRotation;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
