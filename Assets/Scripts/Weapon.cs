using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
	private Animator animator;

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
		animator = (this.transform.parent).transform.parent.transform.parent.gameObject.GetComponent<Animator>();
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
		animator.Play("Attack");
		Debug.Log ("Swing");
	}

	/*
	protected override void OnCollide(Collider2D coll)
	{
		//dano al enemigo por medio del player
		if (coll.tag == "Player" && this.tag == "Fighter") 
		{
			if (coll.name == "Sword")
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

	void onCollisionEnter(Collision other) {
        Debug.Log("aaaaaaa");
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("aaa");
        /*
        if (other.gameObject.GetComponent<SistemaVidas>() != null) {
            other.gameObject.GetComponent<SistemaVidas>().QuitarVida(10);
        }
        
    }
    */
    

}

