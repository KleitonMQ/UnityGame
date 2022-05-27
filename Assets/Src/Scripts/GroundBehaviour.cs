using UnityEngine;
using System.Collections;

public class GroundBehaviour : MonoBehaviour {

	public GameObject chao;

	public float speed;
	public float xDestroy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ControleSpeed ();
		transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);

		if (transform.position.x < -xDestroy || transform.position.x > 40f && chao.name != "PlatFinal1"
		    || SpawnGroundF1.fase == "TRANSICAO1" && this.transform.position.x > 29.24224 && chao.name != "PlatFinal1"
		    || SpawnGroundF1.fase == "TRANSICAO2" && this.transform.position.x > 29.24224 && chao.name != "PlatFinal2") 
		{
			chao.SetActive(false);
		}

	}

	void OnTriggerEnter2D (Collider2D colisao)
	{
		
		if (colisao.gameObject.name == "Player" && Touch.ModoControle == "Fly") 
		{
			Touch.ModoControle = "Correr";

		}
	}

	void ControleSpeed()
	{
		speed = SpawnGroundF1.speedFase;
	}
}
