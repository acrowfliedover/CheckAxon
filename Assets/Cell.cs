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
    public int numLinks = 7;
    public Vector2 motion;
    public float scale =1.1f;
    void Start()
    {
        GenerateCell();
        transform.position = new Vector2(-10.0f, 0.0f);
        cellBody.GetComponent<Rigidbody2D>().velocity = new Vector2(5.0f, 0.0f);
    }

    // Update is called once per frame
    void GenerateCell()
    {

        Rigidbody2D prevBod = cell;
        GameObject newBody = Instantiate(cellBody);
        newBody.transform.parent = transform;
        //newBody.transform.position = transform.position;
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
        //prevBod = newEnd.GetComponent<Rigidbody2D>();
        //testing
    }
    void Update()
    {   
        Vector2 force= -scale * transform.position;
        cellBody.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        Debug.Log(force);
        //motion = new Vector2(Mathf.Sin(Time.time), Mathf.Cos(Time.time));
        //transform.Translate(scale*motion * Time.deltaTime);
    }
}
