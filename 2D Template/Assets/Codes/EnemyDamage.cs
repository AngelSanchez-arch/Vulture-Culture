using System;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 2;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

	// Update is called once per frame
	void Update()
    {
        
    }




	private void OnCollisionEnter2D(Collision2D collision)
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
