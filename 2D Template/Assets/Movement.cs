using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Movement : MonoBehaviour
{
    public float speed = 0.5f;
    private Rigidbody2D rb;
	private Vector2 input;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	internal Vector2 lastPos;

	// Update is called once per frame
	void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize(); //Makes our diagonal movement the same as other movement
        //would be faster w out normalize
    }

    //called once per Physics frame - Used for physics(Used for movement)
    private void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }
}
