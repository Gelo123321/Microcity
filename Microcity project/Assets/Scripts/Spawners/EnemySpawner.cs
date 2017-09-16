using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public float Offset = 10f;
	public float TimeToStartSpawn = 2f;
	public float IntervalSpawn = 1f;
	public int MinAmountSpawn = 1;
	public int MaxAmountSpawn = 2;
	public GameObject EnemyPrefab;
	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawn", TimeToStartSpawn, IntervalSpawn);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn()
	{
		int EnemyCount = Random.Range(MinAmountSpawn, MaxAmountSpawn);
		for(int i = 0; i < EnemyCount; i++)
		{
			int side = Random.Range(0, 4);
			Vector3 pos = new Vector3(0, 0, 0);
			switch(side)
			{
				case 0:
				pos = new Vector3(-10, Random.Range(-4.5f, 4.5f), 0);
				break;
				case 1:
				pos = new Vector3(10, Random.Range(-4.5f, 4.5f), 0);
				break;
				case 2:
				pos = new Vector3(Random.Range(-7.5f, 7.5f), -10, 0);
				break;
				case 3:
				pos = new Vector3(Random.Range(-7.5f, 7.5f), 10, 0);
				break;
			}
			Instantiate(EnemyPrefab, pos, Quaternion.identity);
		}
	}
}
