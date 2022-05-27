using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	//public int maxEnemy;
	public GameObject[] enemyPrefab;

	private bool respawnar;

	// Use this for initialization
	void Start () {

		respawnar = true;

		for (int i = 0 ; i < enemyPrefab.Length; i++) 
		{
			enemyPrefab[i].SetActive(false);
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < enemyPrefab.Length; i++) 
		{
			if (enemyPrefab[i].transform.position.x < - 10)
			{
				enemyPrefab[i].SetActive(false);

			}
		}

		if (this.transform.position.x < -10) 
		{
			respawnar = true;
		}

		for (int i = 0; i < enemyPrefab.Length; i++) 
		{
			if (this.transform.position.x < 13 && this.transform.position.x > 11)
			{
				if (enemyPrefab[i].activeSelf == false && respawnar == true && transform.position.x > 10)
				{
					int isSpawn = Random.Range (0, 2);
					
					if (isSpawn == 0) 
					{
						respawnar = false;
					}
					
					if (isSpawn == 1) 
					{
						if (transform.position.y > 1.0)
						{
							int enemy = Random.Range (0,3);

							enemyPrefab[enemy].SetActive(true);
							enemyPrefab[enemy].transform.position = new Vector3(this.transform.position.x ,enemyPrefab[enemy].transform.position.y, 0);
							respawnar = false;
						} else 
						{
							int enemy = Random.Range (0,2);
							
							enemyPrefab[enemy].SetActive(true);
							enemyPrefab[enemy].transform.position = new Vector3(this.transform.position.x ,enemyPrefab[enemy].transform.position.y, 0);
							respawnar = false;
						}
					}
				}
			}

			if (enemyPrefab[i].activeSelf == true)
			{
				respawnar = false;
			}
		}
	
	}
}
