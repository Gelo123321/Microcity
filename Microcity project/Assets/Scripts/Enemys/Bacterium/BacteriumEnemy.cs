using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriumEnemy : Enemy {
	// Use this for initialization
	void Start () 
	{
		DefaultStart();
	}
	
	// Update is called once per frame
	void Update () 
	{
		DefaultUpdate();
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		DefaultOnCollisionEnter2D(obj);
	}

	protected override void Die()
	{
		IsDie = true;
		Animator.SetBool("IsDie", true);
		Collider.enabled = false;
		AudioManager.PlaySound(1);
		Destroy(gameObject, TimeBeforeDestroy);
	}
}