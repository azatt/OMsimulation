using System.Collections;
using UnityEngine;

public class LifespanPlanted : MonoBehaviour
{
    public GameObject dryPrefab;
    TimeMultipier timeM;
    public GameObject timeObject;
    public int timeToGrow, timeToDie;
    // timeToGrow = 4000, timeToDie = 4500 (tumbleweeds are annual plants so it grows and dies in about 8500 hours
    // timeToDie is slightly longer, because timeToGrow impacts how soon a human can see the plant to remove it and
    // humans can see the plant while it is still small and growing)

    // Start is called before the first frame update
    void Start()
    {
        timeObject = GameObject.FindWithTag("time");
        timeM = timeObject.GetComponent<TimeMultipier>();

        StartCoroutine(Grow());
        StartCoroutine(Wait());
    }

    IEnumerator Grow()
    {
        float random = Random.Range(0.9f, 1.1f);
        yield return new WaitForSeconds(random * timeToGrow / timeM.timeMultipier);
        gameObject.transform.localScale += new Vector3(0.09f, 0.09f, 0.09f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    IEnumerator Wait()
    {
        float random = Random.Range(0.9f, 1.1f);
        yield return new WaitForSeconds((random * timeToDie + timeToGrow) / timeM.timeMultipier);
        SimplePool.Spawn(dryPrefab, transform.position, transform.rotation);
        SimplePool.Despawn(gameObject);
    }
}
