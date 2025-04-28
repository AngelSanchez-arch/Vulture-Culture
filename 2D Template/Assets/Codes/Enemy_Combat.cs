using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
	public int damage = 1;
	public Transform attackpoint;
	public float attackRange;
	public float knockbackForce;
	public LayerMask playerLayer;



	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
			collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
		}
	}


	public void Attack() 
	{
		Collider2D[] hits = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, playerLayer);
		if (hits.Length > 0) 
		{ 
			hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);

		}
	
	}
}
