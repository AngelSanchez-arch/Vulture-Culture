using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SlideScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
    }
}
