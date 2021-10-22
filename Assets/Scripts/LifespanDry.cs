using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class LifespanDry : MonoBehaviour
{
    public GameObject plantedPrefab;
    TimeMultipier timeM;
    public GameObject timeObject;
    public int seedCount, timeUntilBroken;
    
    //private bool slow = true;
    // seedCount = 10.000 (a single tumbleweed can have up to 1/4 of a million seeds)
    // timeUntilBroken = 170 (168 hours in a week)
    // slow = true if timeM.timeMultiplier < 1. otherwise false
    
    // Start is called before the first frame update
    void Start()
    {
        timeObject = GameObject.FindWithTag("time");
        timeM = timeObject.GetComponent<TimeMultipier>();
        //if (timeM.timeMultiplier > 1)
        //    slow = false;
        
        //StartCoroutine(Roll());
    }

    void FixedUpdate()
    {
        int area = FertilityGrid.Areasize;
        int max  = FertilityGrid.Gridsize;
        Vector3 pos = transform.position;
        int x = (int) (pos.x * max / area);
        int y = (int) (pos.z * max / area);
        if (0 <= x && x < max && 0 <= y && y < max)     // To prevent out of range exceptions
        {
            /*if (slow) {
                if (FertilityGrid.Fertility[x, y] > 0)
                {
                    SimplePool.Spawn(plantedPrefab, new Vector3(pos.x, 0.5f, pos.z), transform.rotation);
                    FertilityGrid.Fertility[x, y] -= 1;
                }
            }
            else {*/
                for (int i = 0; i < timeM.timeMultipier; i++) 
                {
                    if (FertilityGrid.Fertility[x, y] > 0)
                    {
                        float r = Random.value;
                        float random = r * Random.Range(-1, 2);
                        SimplePool.Spawn(plantedPrefab, new Vector3(pos.x + Mathf.Sqrt(i) * random, 0.5f, pos.z + Mathf.Sqrt(i) * (1-random)), transform.rotation);
                        FertilityGrid.Fertility[x, y] -= 1;
                    }
                }
            //}
        }
            
        if (seedCount <= 0 || timeUntilBroken <= 0)
            SimplePool.Despawn(gameObject);
    }

    /*IEnumerator Roll()
    {
        for (;;)
        {
            int area = FertilityGrid.Areasize;
            int max  = FertilityGrid.Gridsize;
            Vector3 pos = transform.position;
            int x = (int) (pos.x * max / area);
            int y = (int) (pos.z * max / area);
            if (0 <= x && x < max && 0 <= y && y < max)     // To prevent out of range exceptions
            {
                if (slow) {
                    if (FertilityGrid.Fertility[x, y] > 0)
                    {
                        SimplePool.Spawn(plantedPrefab, new Vector3(pos.x, 0.5f, pos.z), transform.rotation);
                        FertilityGrid.Fertility[x, y] -= 1;
                    }
                }
                else {
                    for (int i = 0; i < timeM.timeMultipier; i++) 
                    {
                        if (FertilityGrid.Fertility[x, y] > 0)
                        {
                            float r = Random.value;
                            float random = r * Random.Range(-1, 2);
                            SimplePool.Spawn(plantedPrefab, new Vector3(pos.x + Mathf.Sqrt(i) * random, 0.5f, pos.z + Mathf.Sqrt(i) * (1-random)), transform.rotation);
                            FertilityGrid.Fertility[x, y] -= 1;
                        }
                    }
                }
            }
            
            if (seedCount <= 0 || timeUntilBroken <= 0)
                SimplePool.Despawn(gameObject);
            
            if (slow)
                yield return new WaitForSeconds(0.02f * t);
            else
                yield return new WaitForSeconds(0.02f);
            // drops seed(s) every minute
        }
    }*/
}
