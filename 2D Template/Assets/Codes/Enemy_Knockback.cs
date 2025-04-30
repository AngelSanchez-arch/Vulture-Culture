using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Knockback : MonoBehaviour
{
   private Rigidbody rb;


	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}


	public void Knockback(Transform playerTransform, float knockbackForce, float stunTime, float stunTime1) 
	{ 
		Vector2 direction = (transform.position - playerTransform.position).normalized;
		rb.linearVelocity = direction * knockbackForce;
		Debug.Log("knockback applied.");
	}

	IEnumerator StunTimer(float stunTime) 
	{ 
		yield return new WaitForSeconds(stunTime);
		rb.linearVelocity = Vector2.zero;

	}
}
