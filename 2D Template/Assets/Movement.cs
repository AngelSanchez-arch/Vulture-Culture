using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector2 input;
    private bool isFacingRight = true;

    private bool canDash = true;
    private bool isSliding;
    private float SlidingPower;
    private float SlidingTime = 0.2f;
    private float SlidingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;
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

    private IEnumerable Dash()
    {
       canDash = true;
       isSliding = true;
       rb.linearVelocity = new Vector2(transform.localScale.x * SlidingPower,0f);
       tr.emitting = true;
       yield return new WaitForSeconds(SlidingTime);
       tr.emitting = false;
       isSliding = false;
       yield return new WaitForSeconds(SlidingCooldown);
       canDash = false;
       
    }
   //ublic void Movecamera(InputAction.CallbackContext ctx)
  //{
    //  Vector2 amount = ctx.ReadValue<Vector2>();
        
  //}
}
