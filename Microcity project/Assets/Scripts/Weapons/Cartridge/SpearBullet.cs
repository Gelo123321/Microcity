using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBullet : Bullet {

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

	//void OnCollisionEnter2D(Collision2D obj)
	//{
		//DefaultOnCollisionEnter2D(obj);
	//}

	protected override void DefaultOnCollisionEnter2D(Collision2D obj)
	{
		// Spear effect
	}


	void OnTriggerEnter2D(Collider2D obj)
	{
		if(obj.gameObject.tag == "Enemy")
			obj.GetComponent<Enemy>().TakeDamage(Damage);
	}
}