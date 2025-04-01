using UnityEngine;

public class Attacking : MonoBehaviour
{
	private GameObject attackArea = default;

	private bool attacking = false;

	private readonly float timeToAttack = 0.25f;
	private float timer = 0f;
	// Start is called before the first frame update
	void Start()
	{
		attackArea = transform.GetChild(0).gameObject;
	}

	//Ubdate is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Attack();
		}
		if (attacking)
		{
			timer += Time.deltaTime;
			if (timer >= timeToAttack)
			{
				timer = 0;
				attacking = false;
				attackArea.SetActive(attacking);
			}
		}
	}
	private void Attack()
	{
		attacking = true;
		attackArea.SetActive(attacking);
	}
}
