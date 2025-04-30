using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class PlayerCombat : MonoBehaviour
{
   public Animator animator;

	public Transform attackPoint;
	public LayerMask enemyLayers;

	public float knockbackForce = 10;
	public float knockbackTime = .15f;
	public float stunTime = 1;
	public float attackRange = 0.5f;
	public int attackDamage = 40;

	public float attackRate = 2f;
	float nextAttacktime = 0f;
	 void Update()
	{
		if (Time.time > nextAttacktime) 
		{ 
		
		}
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			Attack();
			nextAttacktime = Time.time + 1f / attackRate;
		}
	}


	void Attack()
	{
		// Play an attack animation
		animator.SetTrigger("Attack");
		// Detect eniemies in range of attack
		Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, StatsManager.instance.attackRange, enemyLayers);

		// Damage them
		foreach (Collider2D enemy in enemies)
		{
			int damage = 0;
			enemies[0].GetComponent<EnemyDamage>().TakeDamage(-damage);
			enemies[0].GetComponent<Enemy_Knockback>().Knockback(transform, knockbackForce, knockbackTime, stunTime);
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (attackPoint == null)
			return;

		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}
