using UnityEngine;
using System.Collections;

public class SpawnItens : MonoBehaviour {

	public GameObject[] itemPrefab;
	
	private bool respawnar;
	public GameObject booster;
	
	void Start () {

		respawnar = true;
		
		for (int i = 0 ; i < itemPrefab.Length; i++) 
		{
			itemPrefab[i].SetActive(false);
		}
		if (booster != null) 
		{
			booster.SetActive(false);
		}
	}

	void Update () {


		for (int i = 0; i < itemPrefab.Length; i++) 
		{
			if (itemPrefab[i].transform.position.x < - 10)
			{
				itemPrefab[i].SetActive(false);
				respawnar = true;

			}
		}

		for (int i = 0; i < itemPrefab.Length; i++) 
		{

			if (this.transform.position.x < 11)
			{
				if (itemPrefab[i].activeSelf == false && respawnar == true && transform.position.x > 10)
				{
					int isSpawn = Random.Range (0, 2);
					
					if (isSpawn == 0 && booster && respawnar) 
					{
						respawnar = false;
						int isSpawnBoost =Random.Range(0,6);
						if (isSpawnBoost == 1)
						{
							booster.SetActive(true);
							booster.transform.eulerAngles = new Vector2(0,0);
							respawnar = false;
						}
						respawnar = false;
					}
					
					if (isSpawn == 1 && respawnar) 
					{
						if (this.transform.position.y > 0)
						{
							int item = Random.Range (0,itemPrefab.Length);
							itemPrefab[item].SetActive(true);
							itemPrefab[item].transform.eulerAngles = new Vector2(0,0);
							respawnar = false;
						}  
						if (this.transform.position.y < 0 && respawnar)
						{

							itemPrefab[0].SetActive(true);
							itemPrefab[0].transform.eulerAngles = new Vector2(0,0);
							respawnar = false;
						}
					}
				}
			}
			
			if (itemPrefab[i].activeSelf == true)
			{
				respawnar = false;
			}

		}
	}
}
