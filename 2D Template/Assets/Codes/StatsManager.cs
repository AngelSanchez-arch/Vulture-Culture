using UnityEngine;

public class StatsManager : MonoBehaviour
{
	public static StatsManager instance;

	[Header("Combat Stats")]
	public int damage;
	public float attackRange;
	public float knockbackForce;
	public float knockbackTime;
	public float stunTime;

	[Header("Movement Stats")]
	public int speed;

	[Header("Health Stats")]
	public int maxHealth;
	public int currentHealth;


	private void Awake()
	{
		if(instance == null)
			_ = instance == this;
		else
			Destroy(gameObject);
	}
}
