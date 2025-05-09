using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currenthealth;
    public int maxHealth;



    public void ChangeHealth(int amount)
	{
		currenthealth = maxHealth;
	}

	internal void TakeDamage(int damage)
	{
		currenthealth -= damage;

        if (currenthealth <= 0)
        {
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Mainmenu");
        }
    }
}
