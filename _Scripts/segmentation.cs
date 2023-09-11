using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segmentation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject connectedAbove, connectedBelow;
    void Start()
    {
        connectedAbove = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        segmentation aboveSegment = connectedAbove.GetComponent<segmentation>();
        if(aboveSegment != null)
        {
            aboveSegment.connectedBelow = gameObject;
            float spriteBottom = connectedAbove.GetComponent<SpriteRenderer>().bounds.size.x;//this needs to change in real code
            //connectedAbove.GetComponent<SpriteRenderer>().bounds.size.x;//this needs to change in real code
            GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(.85f, 0);//spriteBottom * 
        }
        else
        {
            //GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, 0);
        }
    }
}
