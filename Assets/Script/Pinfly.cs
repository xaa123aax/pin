using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinfly : MonoBehaviour
{
    public float speed=5;
    private bool isFly=false;
    private bool isReach=false;
    private Transform Startpoint;
    public Transform circle;
    private Vector3 targetcirclepos;


    void Start()
    {
        Startpoint = GameObject.Find("StartPoint").transform;
        circle = GameObject.Find("Circle").transform;
        targetcirclepos = circle.position;
        targetcirclepos.y-= 1.55f;
    }

   
    void Update()
    {
        if (isFly == false)
        {
            if (isReach == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, Startpoint.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, Startpoint.position )< 0.05f)
                {
                    isReach = true;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetcirclepos, speed * Time.deltaTime);
            if(Vector3.Distance(transform.position,targetcirclepos)< 0.05f)
            {
                transform.position = targetcirclepos;
                transform.parent = circle;
                isFly = false;  
            }
        }
    }

    public void StartFly()
    {
        isFly = true;
        isReach = true;
    }
}
