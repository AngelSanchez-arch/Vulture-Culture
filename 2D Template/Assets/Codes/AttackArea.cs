using UnityEngine;

public class AttackArea : MonoBehaviour
{
	private readonly int damage = 3;
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.GetComponent<Health>() != null)
		{
			Health health = collider.GetComponent<Health>();
			health.TakeDamage(damage);
		}
	}


}
