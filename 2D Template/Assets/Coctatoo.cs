using UnityEngine;
public class Coctatoo : MonoBehaviour
{
    public Animator animator;
    private bool canStun;
	private GameObject nextSpot;

	public Masks mask;
	public bool coctatoo;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Stun Spot" && collision.GetComponent<StunSpot>().nextSpot != null)
		{
			Debug.Log("dig site");
			canStun = true;
			nextSpot = collision.GetComponent<StunSpot>().nextSpot;


		}
		Debug.Log(" Nope");
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Stun Spot")
		{
			Debug.Log("left Stun site");
			canStun = false;
			nextSpot = null;

		}
		Debug.Log(" Nope");
	}
}
