using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Timeline;

public class Switch : MonoBehaviour
{
    public GameObject wall;
    public bool Ispressed;
    [SerializeField] private Animator Wallanim;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Wallanim = wall.GetComponent<Animator>();
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D Collider)
    {        
        if (CompareTag("Trap")) //This Causes it to trigger
        {
            Debug.Log("yay");
            Wallanim.enabled = true;
            //wall.transform.position = Vector2(1.0f, 1.0f);
        }
    }
} 

