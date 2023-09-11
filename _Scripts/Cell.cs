using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D cell;
    public GameObject cellBody;
    public GameObject axonLinks;
    public GameObject cellEnd;
    public int numLinks;
    public int numCells;
    int currentCell=0;
    public Vector2 motion;
    public float scale;
    public static GameObject[] myBodies=new GameObject[2];
    
    void Start()
    {
        for(int i = 0; i < numCells; i++) { GenerateCell(); }
        scale = -1f;

    }

    // Update is called once per frame
    void GenerateCell()
    {

        Rigidbody2D prevBod = cell;
        GameObject newBody = Instantiate(cellBody);
        myBodies[currentCell++]=newBody;
        newBody.transform.parent = transform;
        HingeJoint2D bodyHj = newBody.GetComponent<HingeJoint2D>();
        bodyHj.connectedBody = prevBod;
        prevBod = newBody.GetComponent<Rigidbody2D>();
       
        for (int i = 0; i < numLinks; i++)
        {
            GameObject newSeg = Instantiate(axonLinks);
            newSeg.transform.parent= transform;
            newSeg.transform.position = transform.position;
            HingeJoint2D hj = newSeg.GetComponent<HingeJoint2D>();
            hj.connectedBody = prevBod;
            prevBod = newSeg.GetComponent<Rigidbody2D>();
        }
        GameObject newEnd = Instantiate(cellEnd);
        newEnd.transform.parent = transform;
        newEnd.transform.position = transform.position;
        HingeJoint2D endHj= newEnd.GetComponent<HingeJoint2D>();
        endHj.connectedBody = prevBod;
    }
    void Update()
    {   
       
    }
    void FixedUpdate()
    {
        //cellBody.transform.position += new Vector2(-1, 0);
        foreach (var body in myBodies){
            Vector2 force = body.transform.position * scale;
            //Vector2 force = new Vector2(Mathf.Sin(Time.time),Mathf.Cos(Time.time));
            body.GetComponent<Rigidbody2D>().AddForce(force);
        }
       // force = myBody.transform.position * scale;
        //Vector2 force = new Vector2(Mathf.Sin(Time.time),Mathf.Cos(Time.time));
        //myBodies[0].GetComponent<Rigidbody2D>().AddForce(force);
        //Debug.Log(force);, ForceMode2D.Impulse
        //motion = new Vector2(Mathf.Sin(Time.time), Mathf.Cos(Time.time));
        //transform.Translate(scale*motion * Time.deltaTime);
    }
}
