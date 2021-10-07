using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePool : MonoBehaviour
{
    public GameObject dryPrefab, plantedPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        WeedPool.Preload(dryPrefab, 50);
        SeedPool.Preload(plantedPrefab, 50);
    }
}
