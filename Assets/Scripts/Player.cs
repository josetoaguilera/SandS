using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover 
{
	private bool isAlive = true;
	private void FixedUpdate()
	{
		
        //float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");

		//if(isAlive)
			//UpdateMotor (new Vector3 (x, y, 0));
	}
	protected override void Death ()
	{

		isAlive = false;
		Destroy (gameObject);
		GameManager.instance.deathMenuAnim.SetTrigger("Show");

	}

}
