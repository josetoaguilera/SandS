using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
	//Daño
	public int damagePoint = 1;
	public float pushForce = 2.0f;

	//Cooldown
	private float cooldown = 0.5f;
	private float lastSwing;

	//Upgrade
	public int weaponLevel = 0;
	private SpriteRenderer spriteRenderer;

	protected override void Start()
	{
		base.Start();
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	protected override void Update()
	{
		base.Update();

		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			if (Time.time - lastSwing > cooldown) 
			{
				lastSwing = Time.time;
				Swing();					
			}
		}								
	}

	private void Swing()
	{
		Debug.Log ("Swing");
	}

	protected override void OnCollide(Collider2D coll)
	{
		if (coll.tag == "SwordEnemy") 
		{
			if (coll.name == "Player")
				return;

			//objeto de daño
			Damage dmg = new Damage
			{
				damageAmount = damagePoint,
				origin = transform.position,
				pushForce = pushForce
			};

			coll.SendMessage ("ReceiveDamage", dmg);
		}


	}

}

