using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
	//Experiencia
	public int xpValue = 1;

	//Logica
	public float triggerLenght = 1;
	public float chaseLenght = 5;
	public float stoppinglenght = 0.1f;
	private bool chasing;
	private bool collidingWithPlayer;
	private Transform playerTransform;
	private Vector3 startingPosition;
	private Vector3 actualPos;

	//Hitbox
	private BoxCollider2D hitbox;
	private Collider2D[] hits = new Collider2D[10];
	public ContactFilter2D filter;

	protected override void Start()
	{
		base.Start ();
		//ojo con Game Manager
		playerTransform = GameObject.Find("Player").transform;
		startingPosition = transform.position;
		hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
		actualPos = startingPosition;
	}

	private void FixedUpdate()
	{
		//esta en rango?
		if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLenght) 
		{
			if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLenght)
				chasing = true;

			if (chasing)
			{
				if(Vector3.Distance(playerTransform.position, actualPos) <= stoppinglenght){
					UpdateMotor (startingPosition - transform.position);
					chasing = false;
				}
				else if (!collidingWithPlayer)
				{
					actualPos = (playerTransform.position - transform.position).normalized;
					UpdateMotor ((playerTransform.position - transform.position).normalized);
				}
			} else {
				UpdateMotor (startingPosition - transform.position);
			}
		}
		else 
		{
			UpdateMotor (startingPosition - transform.position);
			chasing = false;
		}

	


		//revisar si esta sobreponiendose
		collidingWithPlayer = false;
		boxCollider.OverlapCollider (filter, hits);
		for (int i = 0; i < hits.Length; i++) 
		{
			if (hits [i] == null)
				continue;

			if (hits [i].tag == "Fighter" && hits [i].name == "Player")
			{ 
				collidingWithPlayer = true;
			}

			hits [i] = null;
		}
	}

	protected override void Death ()
	{
		Destroy (gameObject);
	
	}
}
