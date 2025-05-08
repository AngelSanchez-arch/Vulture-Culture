using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Animator animator;
    public float vertical;
    public float horizontal;
    public float speed;
    private Rigidbody2D rb;
    private Vector2 input;
    private bool UpFacing = true;
    private bool isFacingRight = true;
    public ActionMap playerActions;
    public InputAction sliding;
    private bool canSlide = true;
    bool slide;
    private bool DownFacing = true; 
    private bool IsSliding;
    private float SlidingPower = 5f;
    private float SlidingTime = 0.2f;
    private float SlidingCooldown = 1f;
    private Vector2 LastDirection;
    private bool canDig;
    private bool canStun; 
    private GameObject nextSpot;
    private bool isKnockedBack;

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
        
        if (input!=Vector2.zero)
        {
            LastDirection = input;
        }
        

        vertical = Input.GetAxisRaw("Vertical") * speed;

        DownFacing = LastDirection.y<0;
        animator.SetBool("DownFacing", DownFacing);
        UpFacing = LastDirection.y>0;
        animator.SetBool("UpFacing", UpFacing);
        if (DownFacing == true)
        {
            
            animator = GetComponent<Animator>();
            Debug.Log(animator);
        }
        if (UpFacing == true)
        {

            animator = GetComponent<Animator>();
            Debug.Log(animator);
        }
        input.Normalize(); //Makes our diagonal movement the same as other movement
        //would be faster w out normalize
        animator.SetFloat("Speed", input.magnitude * speed);
       

        vertical = Input.GetAxisRaw("Vertical");
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
        if (isKnockedBack) 
        {
            float horizontal = Input.GetAxis("Horzontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 ||
                horizontal < 0 && transform.localScale.x > 0) 
            { 
                Flip();
                animator.SetFloat("horizontal", Mathf.Abs(horizontal));
                animator.SetFloat("vertical", Mathf.Abs((vertical)));

				rb.linearVelocity = new Vector2(horizontal, vertical) * StatsManager.instance.speed;
            }

		}
        if (IsSliding)
        {
            return;
        }       
        rb.linearVelocity = input * speed;
        
    }
    private void Flip()
    {
            if (horizontal < 0f)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (horizontal > 0f)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }

    }
    private IEnumerator Dash()
    {
       
       canSlide = false;
       IsSliding = true;
       animator.SetBool("IsSliding", true);
       Debug.Log(animator.GetFloat("Speed"));
        float x = GetComponent<SpriteRenderer>().flipX ? -1:1 ;
       rb.linearVelocity = new Vector2(x * SlidingPower, 0f); //inside of Bracket xDirection           
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



	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Dig Spot" && collision.GetComponent<DigSpot>().nextSpot != null)
		{
			Debug.Log("Stun site");
			canDig = true;
			nextSpot = collision.GetComponent<DigSpot>().nextSpot;


		}
		Debug.Log(" Nope");
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Dig Spot")
		{
			Debug.Log("left stun site");
			canDig = false;
			nextSpot = null;

		}
		Debug.Log(" Nope");
	}




	public void Dig()
    {
        if(!GetComponent<Woodpecker>().enabled)
        {
            return;
        }
        if(canDig)
        {

         transform.position = nextSpot.transform.position;
        }
        else
        {
            Debug.Log("not at a Dig Site!");
        }
    }

    public void Stun() 
    { 
        if (!GetComponent<Coctatoo>().enabled) 
        {
            return; 
        }
        if (canStun)
        {

            transform.position = nextSpot.transform.position;
        }
        else 
        {
            Debug.Log("not at a Stun Site!");
        }
    }
}
