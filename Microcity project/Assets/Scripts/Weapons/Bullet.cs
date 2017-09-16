using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


	public string Name = "Bullet";


	[HeaderAttribute("Bullet Stats")]
	public float Speed = 1.0f;
	public float Damage = 1.0f;
	public float Distance = 10.0f;


	[HeaderAttribute("Script Settings")]
	//


	protected GameObject Player;
	protected Vector3 Direction;


	// Default Unity functions
	protected virtual void DefaultStart () 
	{
		Player = GameObject.FindWithTag("Player");
		Direction = this.transform.up;

		LookAtDirection();
	}
	
	protected virtual void DefaultUpdate () 
	{
		Move();
		LimitFlightDistance();
	}

	protected virtual void DefaultOnCollisionEnter2D(Collision2D obj)
	{
		if(obj.gameObject.tag == "Enemy")
			Die();
	}
	// End

	protected virtual void Move()
	{
		transform.Translate(Direction * Speed * Time.deltaTime);
	}

	protected virtual void LookAtDirection()
	{
 		transform.rotation = Player.transform.rotation; 
	}

	protected virtual void LimitFlightDistance()
	{
		if(transform.position.x > Distance || transform.position.x < -Distance ||
		   transform.position.y > Distance || transform.position.y < -Distance ||
		   transform.position.z > Distance || transform.position.z < -Distance)
			Die();
	}

	protected virtual void Die()
	{
		Destroy(gameObject);
	}
}
