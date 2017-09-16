using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartridgeBullet : Bullet {

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
}
