using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	public float Health;
	public float Damage;
	public float AttackSpeed;
	private float StartHealth = 10;
	private float StartDamage = 1;
	private float StartAttackSpeed = 1;

	void Awake()
	{
		Health = StartHealth;
		Damage = StartDamage;
		AttackSpeed = StartAttackSpeed;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
