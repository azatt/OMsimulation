using System.Collections;
using UnityEngine;

public class LifespanDry : MonoBehaviour
{
    public GameObject plantedPrefab;
    TimeMultipier timeM;
    public GameObject timeObject;
    public int seedCount, timeUntilBroken;
    
    private bool slow = true;
    private float t, t2;
    // seedCount = 10.000 (a single tumbleweed can have up to 1/4 of a million seeds)
    // timeUntilBroken = 170 (168 hours in a week)
    // slow = true if timeM.timeMultiplier < 1. otherwise false 
    // t = timeM.timeMultiplier, t2 = sqrt(t)
    
    // Start is called before the first frame update
    void Start()
    {
        timeObject = GameObject.FindWithTag("time");
        timeM = timeObject.GetComponent<TimeMultipier>();
        t = timeM.timeMultipier;
        t2 = Mathf.Sqrt(t);
        if (t > 1)
            slow = false;
        
        StartCoroutine(Roll());
    }

    IEnumerator Roll()
    {
        for (;;)
        {
            if (slow)
                yield return new WaitForSeconds(0.02f * t);
            else
                yield return new WaitForSeconds(0.02f);
            // drops seed(s) every minute

            int area = FertilityGrid.Areasize;
            int max  = FertilityGrid.Gridsize;
            int x = (int) (transform.position.x * max / area);
            int y = (int) (transform.position.z * max / area);
            if (0 <= x && x < max && 0 <= y && y < max)     // To prevent out of range exceptions
            {
                if (slow) {
                    if (FertilityGrid.Fertility[x, y] > 0)
                    {
                        SimplePool.Spawn(plantedPrefab, transform.position, transform.rotation);
                        FertilityGrid.Fertility[x, y] -= 1;
                    }
                }
                else {
                    for (int i = 0; i < t; i++) 
                    {
                        if (FertilityGrid.Fertility[x, y] > 0)
                        {
                            SimplePool.Spawn(plantedPrefab, transform.position + new Vector3(t2 * Random.value, 0, t2 * Random.value), transform.rotation);
                            FertilityGrid.Fertility[x, y] -= 1;
                        }
                    }
                }
            }
            
            if (seedCount <= 0 || timeUntilBroken <= 0)
                SimplePool.Despawn(gameObject);
        }
    }
}
