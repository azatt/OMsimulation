using UnityEngine;

public class CreatePool : MonoBehaviour
{
    public GameObject dryPrefab, plantedPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SimplePool.Preload(dryPrefab, 50);
        SimplePool.Preload(plantedPrefab, 50);
        //WeedPool.Preload(dryPrefab, 50);
        //SeedPool.Preload(plantedPrefab, 50);
    }
}
