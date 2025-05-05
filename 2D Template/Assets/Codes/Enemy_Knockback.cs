using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Knockback : MonoBehaviour
{
   private Rigidbody rb;
	private NewEnemyAI NewEnemyAI;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		NewEnemyAI = GetComponent<NewEnemyAI>();
	}


	public void Knockback(Transform playerTransform, float knockbackForce, float knockbackTime, float stunTime)
	{
		NewEnemyAI.ChangeState(NewEnemyAI.EnemyState.Knockback);
		StartCoroutine(StunTimer(knockbackTime, stunTime));
		Vector2 direction = (transform.position - playerTransform.position).normalized;
		rb.linearVelocity = direction * knockbackForce;
		Debug.Log("knockback applied.");
	}

	IEnumerator StunTimer(float knockbackTime, float stunTime)
	{
		yield return new WaitForSeconds(knockbackTime);
		rb.linearVelocity = Vector2.zero;
		yield return new WaitForSeconds(stunTime);
		NewEnemyAI.ChangeState(NewEnemyAI.EnemyState.Idle);
	}
}
