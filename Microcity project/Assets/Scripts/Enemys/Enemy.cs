using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


	public string Name = "Enemy";


	[HeaderAttribute("Enemy Stats")]
	public float Health = 1.0f;
	public float Speed = 1.0f;
	public float ContactDamage = 1.0f;


	[HeaderAttribute("Script Settings")]
	public float TimeBeforeBorn = 1.0f;
	public float TimeBeforeDestroy = 1.0f;


	protected bool IsBorn = false;
	protected bool IsDie = false;
	protected GameObject Player;
	protected Animator Animator;
	protected Collider2D Collider;
	protected AudioManager AudioManager;


	// Default Unity functions
	protected virtual void DefaultStart()
	{
		Animator = GetComponent<Animator>();
		Collider = GetComponent<Collider2D>();
		Player = GameObject.FindWithTag("Player");
		AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

		StartCoroutine(Born());
	}
	protected virtual void DefaultUpdate()
	{
		if(!IsBorn || IsDie)	
			return;

		Move();
		LookAtPlayer();

		if(Health <= 0)
			Die();
	}
	protected virtual void DefaultOnCollisionEnter2D(Collision2D obj)
	{
		if(obj.gameObject.tag == "Player")
			Die();
		if(obj.gameObject.tag == "Bullet")
			TakeDamage(obj.gameObject.GetComponent<Bullet>().Damage);
	}
	// End 

	protected virtual IEnumerator Born()
	{
		yield return new WaitForSeconds(TimeBeforeBorn);
		IsBorn = true;
	} 

	protected virtual void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, Vector2.zero, Speed * Time.deltaTime);
	} 

	protected virtual void LookAtPlayer()
	{
		Vector3 difference = Player.transform.position - transform.position;
 		float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
 		transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
	}

	public virtual float Attack()
	{
		return ContactDamage;
	}

	public virtual void TakeDamage(float damage)
	{
		Health -= Mathf.Clamp(damage, 0, Health);
	}

	protected virtual void Die()
	{
		IsDie = true;
		Animator.SetBool("IsDie", true);
		Collider.enabled = false;
		Destroy(gameObject, TimeBeforeDestroy);
	}
}
