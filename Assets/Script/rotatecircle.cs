using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecircle : MonoBehaviour
{

    public float Speed = 90;

    void Start()
    {
        Speed = Random.Range(-360,360);
    }


    void Update()
    {
        transform.Rotate(new Vector3(0, 0, -Speed * Time.deltaTime));
    }
}
    