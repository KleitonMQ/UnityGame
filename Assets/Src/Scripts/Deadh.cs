using UnityEngine;
using System.Collections;

public class Deadh : MonoBehaviour {

	public Transform player;
	
	public GameObject explosion;

	public static bool morto;

	public static float countFade;

	// Use this for initialization
	void Start () {
		explosion.SetActive (false);

	
	}
	void onLoadLevel()
	{
		morto = false;
	}
	// Update is called once per frame
	void Update () {

		if (player.position.y < -5.416801f) 
		{
			morto = true;
		}

		if (player.position.x < -8.526166f) 
		{
			morto = true;
		}
		if (countFade > 100) 
		{
			countFade = 0;
			Application.LoadLevel ("menu");


		}

		if (morto) 
		{
			countFade += 30*Time.deltaTime;
		}
	}

	void OnTriggerEnter2D (Collider2D colisao)
	{

		if (colisao.gameObject.tag == "Enemy01" || colisao.gameObject.tag == "Enemy02" 
		    || colisao.gameObject.tag == "Enemy03" || colisao.gameObject.name == "EnemyP") 
		{
			explosion.transform.position = player.position;

			morto = true;
			player.position = new Vector3 (0, -1000.416801f,0);
			explosion.SetActive(true);
		}


	}
	public static float timeFade()
	{
		return countFade;
	}
}
