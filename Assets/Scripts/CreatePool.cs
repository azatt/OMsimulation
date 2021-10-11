using UnityEngine;

public class CreatePool : MonoBehaviour
{
    public GameObject dryPrefab, plantedPrefab;
    public int gridsize, areasize, baseFertility;

    // Start is called before the first frame update
    void Start()
    {
        SimplePool.Preload(dryPrefab, 50);
        SimplePool.Preload(plantedPrefab, 50);

        FertilityGrid.Gridsize = gridsize;
        FertilityGrid.Areasize = areasize;
        FertilityGrid.Fertility = new int[gridsize,gridsize];
        
        for (int i = 0; i < gridsize; i++)
        { 
            for (int j = 0; j < gridsize; j++)
            {
                FertilityGrid.Fertility[i,j] = baseFertility;
            }
        }
    }
}
