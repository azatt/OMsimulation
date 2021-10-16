using System.Linq;
using UnityEngine;

public class ObjectCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("tumbleweed");
        objects = objects.Where(o => o.activeSelf == true).ToArray();
        Debug.Log("Current tumbleweeds alive: " + objects.Length);
    }
}
