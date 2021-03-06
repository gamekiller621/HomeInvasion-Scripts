﻿using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour
{

	public int health = 1;

	public float invulnPeriod = 0;
	float invulnTimer = 0;
	int correctLayer;

	SpriteRenderer spriteRend;

	public int scoreValue = 10;
	//public GameObject explosion;

	public bool damageOnTrigger = true;

	void Start ()
	{
		correctLayer = gameObject.layer;

		// NOTE!  This only get the renderer on the parent object.
		// In other words, it doesn't work for children. I.E. "enemy01"
		spriteRend = GetComponent<SpriteRenderer> ();

		if (spriteRend == null)
		{
			spriteRend = transform.GetComponentInChildren<SpriteRenderer> ();

			if (spriteRend == null)
			{
				Debug.LogError ("Object '" + gameObject.name + "' has no sprite renderer.");
			}
		}
	}

	void OnTriggerEnter2D (Collider2D collision)
	{
		if (damageOnTrigger)
		{
			if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
			{
				return; 
			}

			if (collision.gameObject.tag == "Bullet")
			{
				/*if (explosion)
				{
					Instantiate (explosion, transform.position, transform.rotation);
				}*/
				// do the player collect coin thing
				//collision.gameObject.GetComponent<PlayerController> ().CollectCoin (coinValue);
				health--;
				//Destroy (gameObject);
			}
		}


		if (invulnPeriod > 0)
		{
			invulnTimer = invulnPeriod;
			gameObject.layer = 10;
		}
	}


	void Update ()
	{

		if (health <= 0)
		{
			Destroy (gameObject);
			ScoreManager.score += scoreValue;
		}

		if (invulnTimer > 0)
		{
			invulnTimer -= Time.deltaTime;

			if (invulnTimer <= 0)
			{
				gameObject.layer = correctLayer;
				if (spriteRend != null)
				{
					spriteRend.enabled = true;
				}
			}
			else
			{
				if (spriteRend != null)
				{
					spriteRend.enabled = !spriteRend.enabled;
				}
			}
		}
			
	}

	void Die ()
	{
		Destroy (gameObject);
	}

}
