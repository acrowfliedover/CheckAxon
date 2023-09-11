using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update

    //Refel's BPM=167
    Queue<GameObject> Cells =new Queue<GameObject>();
    Queue<GameObject> Notes =new Queue<GameObject>();
    float circleSize = 3.0f;
    // one queue for displaying notes
    // one list/vector for judging notes, because for each FixedUpdate, need to check all of them.
    Cell script;
    public static int score;


    public static GameControl Instance { get; private set; }

    void Awake()
    {
        Instance = this;


        string myfile = "RefelDiff4.txt";
        string[] myChart = File.ReadAllLines(myfile);
        foreach (string line in myChart)
        {
            //Debug.Log(line);
        }
        script = GetComponent<Cell>();
        script.numLinks = int.Parse(myChart[1]);
        script.numCells = int.Parse(myChart[0]);

        //load settings

        //load notes
        List<string[]> fullData=new List<string[]>();
        for (int i = 2; i < myChart.Length; ++i)
        {
            var NoteData = myChart[i].Split(',');
            fullData.Add(NoteData);
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Touch touch = Input.GetTouch(0);

        Camera.main.transform.position=Camera.main.ScreenToWorldPoint(touch.position);

        Camera.main.orthographicSize *=1.001f;
        //read the next note, if it's past the time threshold, create the note object, add it to the queue
    }
    void FixedUpdate()
    {
        //check if any of the notes within the 
        //Time.deltaTime;
    }
}
