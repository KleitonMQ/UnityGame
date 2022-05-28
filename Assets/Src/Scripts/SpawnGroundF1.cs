using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpawnGroundF1 : MonoBehaviour {
	
	public float maxHeight;
	public float mileScore;
	public float minHeight;
	public float lastRandPosition;
	public float rateSpawn;
	public float speedBasic;
	private float currentSpawn;
	public float p1, p2, p3;
	
	public int maxGround;
	public int QtdGround;
	public int score;
	
	private bool spawn;
	private bool tempo;

	public string fase;
	public static string faseInfo;
	public static float speedFase;
	public static float speedIncrease;
	public float rend;

	public GameObject[] prefab;
	public GameObject[] prefab2;
	public GameObject[] prefab3;
	public GameObject[] prefabT;

	public GameObject lastGroundF1;
	public GameObject lastGroundF2;
	public GameObject firstGroundF2;
	public GameObject firstGroundF3;

	public List<GameObject> ground;
	public List<GameObject> ground2;
	public List<GameObject> ground3;
	public List<GameObject> fly;

	// Use this for initialization
	void Start () {
		score = 0;
		speedIncrease = 0;
		fase = "FASE01";

		for (int i = 0; i < maxGround; i++) {
			GameObject tempPlataforma = Instantiate(prefab[QtdGround]) as GameObject;
			ground.Add(tempPlataforma);
			tempPlataforma.SetActive(false);
			QtdGround++;
			if (QtdGround > 4)
			{
				QtdGround = 0;
			}

		}

		lastGroundF1.SetActive (false);
		lastGroundF2.SetActive (false);
		firstGroundF2.SetActive (false);
		firstGroundF3.SetActive (false);

		speedBasic = -4f;
	}
	
	// Update is called once per frame
	void Update () {
		faseInfo = fase;
		speedFase = speedBasic+ speedIncrease;
		currentSpawn += Time.deltaTime;
		if (currentSpawn > rateSpawn && !tempo) 
		{
			if (fase == "FASE01")
			{
			rateSpawn = Random.Range (0.2f, 0.5f);
			currentSpawn = 0;
			Spawn ();
			}
			if (fase == "FASE02")
			{
			rateSpawn = Random.Range (0f, 0.3f);
			currentSpawn = 0;
			Spawn ();
			}
			if (fase == "FASE03")
			{
			rateSpawn = Random.Range (0f, 0.5f);
			currentSpawn = 0;
			Spawn ();
			}

			if (fase == "TRANSICAO")
			{
			rateSpawn = Random.Range (2f, 1.5f);
			currentSpawn = 0;
			Spawn ();
			}

		}
		if (tempo && currentSpawn > 5.2f)
		{
			tempo = false;
		}

		UpdateScore ();
		faseControll ();

	}
	
	private void Spawn() {

		if (fase == "TRANSICAO") 
		{
			rateSpawn = 1f;
			float rendPositionT = Random.Range (0,11);
			GameObject tempGroundT = null;
			spawn = true;
			for (int i = 0; i < maxGround; i++) {
				if (fly[i].activeSelf == false)
				{
					tempGroundT = fly[i];
					break;
				}

			}

			if (tempGroundT != null) 
			{
				if (spawn)
				{
					if (rendPositionT < 4)
					{
						tempGroundT.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
						tempGroundT.SetActive(true);
						spawn = false;
					}

					if (rendPositionT > 3 && rendPositionT < 7)
					{
						tempGroundT.transform.position = new Vector3(transform.position.x, 2, transform.position.z);
						tempGroundT.SetActive(true);
						spawn = false;
					}

					if (rendPositionT > 6)
					{
						tempGroundT.transform.position = new Vector3(transform.position.x, -2, transform.position.z);
						tempGroundT.SetActive(true);
						spawn = false;
					}
				}
			}
		}
		if (fase == "FASE01" || fase == "FASE02" || fase == "FASE03") 
		{
			float rendPosition = Random.Range (0,11);
			GameObject tempGround = null;
			spawn = true;
			for (int i = 0; i < maxGround; i++) {
				if (fase == "FASE01")
				{
					if (ground[i].activeSelf == false)
					{
						tempGround = ground[i];
						break;
					}
				}

				if (fase == "FASE02")
				{
					if (ground2[i].activeSelf == false)
					{
						tempGround = ground2[i];
						break;
					}
				}

				if (fase == "FASE03")
				{
					if (ground3[i].activeSelf == false)
					{
						tempGround = ground3[i];
						break;
					}
				}
			}
			if (tempGround != null) 
			{
				if (p1 == lastRandPosition && spawn)
				{
					if (rendPosition < 5)
					{
						tempGround.transform.position = new Vector3(transform.position.x, p1, transform.position.z);
						tempGround.SetActive(true);
						lastRandPosition = p1;
						spawn = false;
					}
					
					if (rendPosition > 4)
					{
						tempGround.transform.position = new Vector3(transform.position.x, p2, transform.position.z);
						tempGround.SetActive(true);
						lastRandPosition = p2;
						spawn = false;
					}
				}
				
				if (p2 == lastRandPosition && spawn)
				{
					if (rendPosition == 4 || rendPosition == 3)
					{
						tempGround.transform.position = new Vector3(transform.position.x, p1, transform.position.z);
						tempGround.SetActive(true);
						lastRandPosition = p1;
						spawn = false;
					}
					
					if (rendPosition == 2 || rendPosition == 1 || rendPosition == 0)
					{
						tempGround.transform.position = new Vector3(transform.position.x, p2, transform.position.z);
						tempGround.SetActive(true);
						lastRandPosition = p2;
						spawn = false;
					}
					
					if (rendPosition > 4 && spawn)
					{
						tempGround.transform.position = new Vector3(transform.position.x, p3, transform.position.z);
						tempGround.SetActive(true);
						lastRandPosition = p3;
						spawn = false;
					}
				}
				
				if (p3 == lastRandPosition && spawn)
				{
					if (rendPosition == 2 || rendPosition == 3 || rendPosition == 6)
					{
						tempGround.transform.position = new Vector3(transform.position.x, p1, transform.position.z);
						tempGround.SetActive(true);
						lastRandPosition = p1;
						spawn = false;
					}
					
					if (rendPosition == 0 || rendPosition == 1 || rendPosition == 9 || rendPosition == 7)
					{
						tempGround.transform.position = new Vector3(transform.position.x, p2, transform.position.z);
						tempGround.SetActive(true);
						lastRandPosition = p2;
						spawn = false;
					}
					
					if (rendPosition == 4 || rendPosition == 5 || rendPosition == 8 || rendPosition > 9)
					{
						tempGround.transform.position = new Vector3(transform.position.x, p3, transform.position.z);
						tempGround.SetActive(true);
						lastRandPosition = p3;
						spawn = false;
					}
				}
			}
		}
	}

	private void UpdateScore()
	{
		mileScore += 20*Time.deltaTime;
		if (mileScore > 100) 
		{
			score++;
			mileScore = 0;
		}
//Aumento gradativo da velocidade de corrida.
		if (score == 0) {speedBasic = -4.5f;}
		if (score == 3) {speedBasic = -5.0f;}
		if (score == 8) {speedBasic = -5.5f;}
		if (score == 13) {speedBasic = -6.5f;}
		if (score == 20) {speedBasic = -7.0f;}
		if (score == 30) {speedBasic = -7.5f;}
		if (score == 40) {speedBasic = -8.0f;}
		if (score == 45) {speedBasic = -8.5f;}
		if (score == 60) {speedBasic = -9.0f;}
	}

	void faseControll()
	{
		int caseSwitch = score;
		switch (caseSwitch) 
		{
		case 8:

			fase = "STANDBY";
			currentSpawn += Time.deltaTime;
			if ( !lastGroundF1.activeSelf) 
			{
				lastGroundF1.SetActive(true);
				currentSpawn = 0;
				lastGroundF1.transform.position = new Vector3(transform.position.x, p1, transform.position.z);
				lastRandPosition = p1;
			}
			break;

		case 11:

			for (int i = 0; i < maxGround; i++) {
				Destroy(ground[i]);
			}
			
			if (fase == "STANDBY")
			{
				fase = "TRANSICAO";
				for (int i = 0; i < maxGround; i++) 
				{
					GameObject tempPlataforma = Instantiate(prefabT[QtdGround]) as GameObject;
					fly.Add(tempPlataforma);
					tempPlataforma.SetActive(false);
					QtdGround++;
					if (QtdGround > 4)
					{
						QtdGround = 0;
					}
					
				}
			}
			break;

		case 18:

			fase = "STANDBY";
			break;


		case 19:

			fase = "FASE02";
			BGTransicao.gatilho = "FASE";
			if (firstGroundF2.activeSelf == false)
			{
				for (int i = 0; i < maxGround; i++) {
					GameObject tempPlataforma = Instantiate(prefab2[QtdGround]) as GameObject;
					ground2.Add(tempPlataforma);
					tempPlataforma.SetActive(false);
					QtdGround++;
					if (QtdGround > 4)
					{
						QtdGround = 0;
					}
					
				}
				
				firstGroundF2.transform.position = new Vector3(transform.position.x, p1, transform.position.z);
				firstGroundF2.SetActive(true);
				lastRandPosition = p1;
				tempo = true;
				currentSpawn = 0;
			}
			break;

		case 26:

			fase = "STANDBY";
			lastGroundF2.SetActive(true);
			break;

		case 28:

			for (int i = 0; i < maxGround; i++) {
				Destroy(ground2[i]);
			}
			
			if (fase == "STANDBY")
			{
				fase = "TRANSICAO";
				for (int i = 0; i < maxGround; i++) 
				{
					GameObject tempPlataforma = Instantiate(prefabT[QtdGround]) as GameObject;
					fly.Add(tempPlataforma);
					tempPlataforma.SetActive(false);
					QtdGround++;
					if (QtdGround > 4)
					{
						QtdGround = 0;
					}
					
				}
			}
			break;

		case 34:
			
			fase = "STANDBY";
			break;
		case 35:

			fase = "FASE03";
			BGTransicao.gatilho = "FASE";
			if (firstGroundF3.activeSelf == false)
			{
				for (int i = 0; i < maxGround; i++) {
					GameObject tempPlataforma = Instantiate(prefab3[QtdGround]) as GameObject;
					ground3.Add(tempPlataforma);
					tempPlataforma.SetActive(false);
					QtdGround++;
					if (QtdGround > 4)
					{
						QtdGround = 0;
					}
				}
				
				firstGroundF3.transform.position = new Vector3(transform.position.x, p1, transform.position.z);
				firstGroundF3.SetActive(true);
				lastRandPosition = p1;
				tempo = true;
				currentSpawn = 0;
				for (int i = 0; i < maxGround; i++) {
					Destroy(ground2[i]);
				}
				for (int i = 0; i < maxGround; i++) {
					Destroy(fly[i]);
				}
			}
			break;
		}
	}
}