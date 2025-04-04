using System;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public int damage = 2;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

	// Update is called once per frame
	void Update()
    {
        
    }




	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.gameObject.tag == "Player") 
        {
            playerHealth.TakeDamage(damage);
		}
    }

	internal void TakeDamage(int attackDamage)
	{
		throw new NotImplementedException();
	}
}
