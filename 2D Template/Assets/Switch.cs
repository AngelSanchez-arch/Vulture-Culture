using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Switch : MonoBehaviour
{
    Rigidbody rb;
    public bool Ispressed;
    private GameObject Player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // This Causes it to trigger
       // if (collision.GetComponent<Player>() != null)
        //{
            //transform.position = Vector2(1.0f, 1.0f);
        //}
        //
    }
    
}

