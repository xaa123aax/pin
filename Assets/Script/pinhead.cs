using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinhead : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pinhead")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Gameover();
        }
    }

}
