using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot : MonoBehaviour {
	public float Health = 1f;
	public float Speed = 2f;
	public float Damage = 1f;

	private GameObject Player;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		LookAtPlayer();

		if(Health <= 0)
			Die();
	}

	void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, Vector2.zero, Speed / 2 * Time.deltaTime);
	}

	void TakeDamage(float damage)
	{
		Health -= damage;
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		if(obj.gameObject.tag == "Player")
			Die();
		if(obj.gameObject.tag == "Bullet")
			TakeDamage(obj.gameObject.GetComponent<Bullet>().Damage);
	}

	void Die()
	{
		Destroy(gameObject);
	}

	void LookAtPlayer()
	{
		Vector3 difference = Player.transform.position - transform.position;
 		float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
 		transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
	}
}
