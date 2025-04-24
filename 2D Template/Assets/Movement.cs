using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System;
using UnityEditor.Tilemaps;
using UnityEditor;

public class Movement : MonoBehaviour
{
    public Animator animator;
    public float vertical;
    public float horizontal;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 input;
    private bool isFacingRight = true;
    public ActionMap playerActions;
    public InputAction sliding;
    private bool canSlide = true;
    bool slide;
    private bool IsSliding;
    private float SlidingPower = 5f;
    private float SlidingTime = 0.2f;
    private float SlidingCooldown = 1f;
    

    [SerializeField] private TrailRenderer tr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {
        playerActions = new ActionMap();
    }

    internal Vector2 lastPos;
	// Update is called once per frame
	void Update()
    {
        if (IsSliding)
        {
            IsSliding = true;
        }
        if (IsSliding == true)
        {
            animator = GetComponent<Animator>();
            Debug.Log(animator);
        } 
        horizontal = Input.GetAxisRaw("Horizontal") * speed;
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize(); //Makes our diagonal movement the same as other movement
        //would be faster w out normalize
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
      
       
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift) && canSlide)
        {
          StartCoroutine(Dash());
        }

        Flip();
    }

    //called once per Physics frame - Used for physics(Used for movement)
    private void FixedUpdate()
    {
        if (IsSliding)
        {
            return;
        }       
        rb.linearVelocity = input * speed;
        
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector2 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private IEnumerator Dash()
    {
       
        canSlide = false;
       IsSliding = true;
        animator.SetBool("IsSliding", true);
        Debug.Log(animator.GetFloat("Speed"));
        rb.linearVelocity = new Vector2(transform.localScale.x * SlidingPower, 0f); //inside of Bracket xDirection
       tr.emitting = true;
       yield return new WaitForSeconds(SlidingTime);
       tr.emitting = false;
       IsSliding = false;
        animator.SetBool("IsSliding", false);
        Debug.Log(animator.GetFloat("Speed"));
        yield return new WaitForSeconds(SlidingCooldown);
       canSlide = true;
      
    }
   public void Movecamera(InputAction.CallbackContext ctx)
   {
        Debug.Log("you are sliding!");
      Vector2 amount = ctx.ReadValue<Vector2>();    
   }

    public void Slide(InputAction.CallbackContext ctx)
    {
        StartCoroutine(Dash());
    }
}
