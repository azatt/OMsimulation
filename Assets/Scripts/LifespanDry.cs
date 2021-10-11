using System.Collections;
using UnityEngine;

public class LifespanDry : MonoBehaviour
{
    public GameObject plantedPrefab;
    TimeMultipier timeM;
    public GameObject timeObject;
    public int seedCount, timeUntilBroken;
    
    // Start is called before the first frame update
    void Start()
    {
        timeObject = GameObject.FindWithTag("time");
        timeM = timeObject.GetComponent<TimeMultipier>();

        StartCoroutine(Roll());
    }

    IEnumerator Roll()
    {
        for (;;)
        {
            yield return new WaitForSeconds(1 / timeM.timeMultipier);

            int area = FertilityGrid.Areasize;
            int max  = FertilityGrid.Gridsize;
            int x = (int) (transform.position.x * max / area);
            int y = (int) (transform.position.z * max / area);
            if (0 <= x && x < max && 0 <= y && y < max)     // To prevent out of range exceptions
            {
                if (FertilityGrid.Fertility[x,y] > 0)
                {
                    SimplePool.Spawn(plantedPrefab, transform.position, transform.rotation);
                    FertilityGrid.Fertility[x, y] -= 1;
                }
            }
            
            if (seedCount <= 0 || timeUntilBroken <= 0)
                SimplePool.Despawn(gameObject);
        }
    }
}
