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

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Roll()
    {
        for (;;)
        {
            yield return new WaitForSeconds(10 / timeM.timeMultipier);
            SimplePool.Spawn(plantedPrefab, transform.position, transform.rotation);
            if (seedCount <= 0 || timeUntilBroken <= 0)
                SimplePool.Despawn(gameObject);
        }
    }
}
