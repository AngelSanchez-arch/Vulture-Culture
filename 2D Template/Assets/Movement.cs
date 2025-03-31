using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
<<<<<<< HEAD
    private Vector2 input;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
=======
	private Vector2 input;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
>>>>>>> 95b5ea33d2e1cc4573841e1301dc1cf661e52d5c
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
