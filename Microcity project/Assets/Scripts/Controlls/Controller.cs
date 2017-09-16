using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
	public PlayerStats playerStats;
	public GameObject Weapon;
	public GameObject FirePoint;
	//private float Speed = 1.0f;
	private Vector2 mousePos;
 	private Vector3 screenPos;
	private bool IsReadyToFire = true;
	public AudioManager AudioManager;
	private Animator Animator;
	private bool IsDie = false;
	// Use this for initialization
	void Start () {
		Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(IsDie)
			return;

		MoveEye(new Vector2(0, 0));

		if(Input.GetMouseButton(0))
			Fire();

		if(playerStats.Health <= 0)
			Die();
	}

	public void MoveEye(Vector2 direction)
	{
		//Gets the mouse position
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));
 
		//Draws a ray from the pivot point from object to the mouse position
		Debug.DrawRay(transform.position, mousePosition - transform.position, Color.cyan);
 
		//Rotates the object
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);
	}

	public void Fire()
	{
		if(IsReadyToFire)
		{
			Debug.Log("Fire");
			AudioManager.PlaySound(0);
			Instantiate(Weapon, FirePoint.transform.position, Quaternion.identity);
			StartCoroutine(Reload());
			IsReadyToFire = false;
		}
	}

	private IEnumerator Reload()
	{
		yield return new WaitForSeconds(playerStats.AttackSpeed);
		IsReadyToFire = true;
		Debug.Log("Reload");
	}

	void TakeDamage(float damage)
	{
		playerStats.Health -=damage;
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		if(obj.gameObject.tag == "Enemy")
			TakeDamage(obj.gameObject.GetComponent<Enemy>().Attack());
	}

	void Die()
	{
		IsDie = true;
		AudioManager.PlaySound(3);
		Animator.SetBool("IsDie", true);
		Destroy(gameObject, 0.5f);
	}
}
