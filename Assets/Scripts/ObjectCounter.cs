using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ObjectCounter : MonoBehaviour
{
    private string textPath;
    private List<string> output = new List<string>();
    private int elapsedTime = 0;
    public GameObject timeObject;
    TimeMultipier timeM;

    void Start()
    {
        timeM = timeObject.GetComponent<TimeMultipier>();
        StartCoroutine("WriteOutput");
    }

    // Update is called once per frame
    void Update() { }

    IEnumerator WriteOutput()
    {
        for (; ; )
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("tumbleweed");
            objects = objects.Where(o => o.activeSelf == true).ToArray(); // array of active tumbleweed objects
            elapsedTime += 1; // the amount of game seconds elapsed
            //output.Add("Time: " + elapsedTime + "\t\t" + "Count: " + objects.Length);
            output.Add(elapsedTime + " " + objects.Length);

            yield return new WaitForSeconds(1 / timeM.timeMultipier);
        }
    }
    private void OnApplicationQuit()
    {
        CreateTextFile();
    }

    void CreateTextFile()
    {
        string dir = Application.dataPath + "/Output";
        string txtname = System.DateTime.Now.ToString("HH.mm yyyy-MM-dd") + ".txt";
        textPath = Path.Combine(dir, txtname);

        using (StreamWriter writer = new StreamWriter(textPath, false))
        {
            foreach (string line in output) { writer.WriteLine(line); }
            writer.Close();
        }
    }



}
