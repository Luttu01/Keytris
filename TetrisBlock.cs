using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{

    private float previousTime;
    public float falltime = 0.8f;
    public static int height = 20;
    public static int width = 10;
    public Vector3 rotationPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {  
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }

        }
        //Rotate Left
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            if (!ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            }

        }

        //Rotate Right
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            if (!ValidMove())
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            }

        }

        if (Time.time - previousTime > (Input.GetKeyDown(KeyCode.DownArrow) ? falltime/10 : falltime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!ValidMove())
            {
                transform.position -= new Vector3(0, -1, 0);
            }

            previousTime = Time.time;
        }
    }
  
    bool ValidMove()
    {
        foreach(Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX <0 || roundedX >= width || roundedY <0 ||roundedY >= 20)
            {
                return false;
            }   
        }
        return true;
    }
}
