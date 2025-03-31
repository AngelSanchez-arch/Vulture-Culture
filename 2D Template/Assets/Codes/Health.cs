using System;
using UnityEngine;

public class Health : MonoBehaviour
{
	public int health, maxHealth;
	public static event Action OnPlayerDamaged;
	public static event Action OnPlayerDeath;
	public ImagePosition healthBar;




	// Start is called before the first frame update
	public void Start()
	{
		health = maxHealth;
	}
	public void TakeDamage(int amount)
	{
		health -= amount;
		OnPlayerDamaged?.Invoke();

		if (health <= 0)
		{

		}
	}
}
