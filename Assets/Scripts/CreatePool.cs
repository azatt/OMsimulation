using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePool : MonoBehaviour
{
    public GameObject prefab;
    
    // Start is called before the first frame update
    void Start()
    {
        SimplePool.Preload(prefab, 100);
    }
}
