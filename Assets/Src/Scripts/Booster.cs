using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour {

	private Transform enemy;
	private Transform player;
	private Animator animator;
	public Transform moedaT;
	private SpriteRenderer alpha;

	public float count;
	public float countBooster;

	private float speedP;

	public sbyte boost;
	private bool boostFly;
	private bool moeda;
	//private bool verify;

	void Start () {

		enemy = Touch.enemyPS;
		player = Touch.playerS;
		alpha = this.GetComponent<SpriteRenderer>();
	//	verify = false;
		speedP = 0.1f;
		count = 0;
		boost = 0;
		boostFly = false;
		countBooster = 0;
	}
	
	// Update is called once per frame
	void Update () {

		pegouMoeda ();
		
		if (boostFly) 
		{
			
			countBooster += Time.deltaTime;
			if (countBooster >= 5)
			{
				SpawnGroundF1.speedIncrease += 1f;
				boostFly = false;
				countBooster = 0;

			}
			enemy.transform.position -= new Vector3 (speedP * 20 * Time.deltaTime, 0, 0);

		}

		if (boost != 0) 
		{

			countBooster += Time.deltaTime;
			if (countBooster >= 5)
			{
				SpawnGroundF1.speedIncrease += 1f;
				boost = 0;
				countBooster = 0;

			}
		}

		if (this.transform.position.x > 8) 
		{
			alpha.color = new Color(1,1,0.627f,1);
		}

		if (boost == -1 && enemy.transform.position.x > -10.13103) 
		{
			enemy.transform.position -= new Vector3 (0.2f * Time.deltaTime, 0, 0);
			
			if (player.transform.position.x < -4.970221f)
			{
				player.transform.position += new Vector3 (speedP * Time.deltaTime, 0, 0);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D colisao)
	{
		if (colisao.gameObject.name == "Player" && this.name == "Booster" && !moeda) 
		{
			countBooster = 0;
			SpawnGroundF1.speedIncrease -= 1f;
			boost = -1;
			animator = moedaT.GetComponent<Animator>();
			animator.SetBool("Colidiu", true);
			moeda = true;
			Hud.contadorUC++;
		}
		if (colisao.gameObject.name == "Player" && this.name == "Fly") 
		{
			boost = 0;
			boostFly = true;
			Touch.ModoControle = "Estatico";
			this.transform.position = new Vector3(0,100,0);
			BGTransicao.gatilho = "TRANSICAO";
			Hud.contadorDC += 1;

		}
		if (colisao.gameObject.name == "Player" && this.name == "Moeda" && !moeda) 
		{
			animator = moedaT.GetComponent<Animator>();
			animator.SetBool("colidiu", true);
			moeda = true;
			Hud.contadorUK += 1;
		}

	}

	void OnTriggerStay2D(Collider2D colisao)
	{   //inimigos pegam cristai
		if ((colisao.gameObject.name == "Enemy01" || colisao.gameObject.name == "Enemy02"
		     || colisao.gameObject.name == "Enemy03") && this.name == "Moeda" && !moeda && this.transform.position.x < 7) {
			animator = moedaT.GetComponent<Animator> ();
			animator.SetBool ("colidiu", true);
			moeda = true;
		}
		if ((colisao.gameObject.name == "Enemy01" || colisao.gameObject.name == "Enemy02"
		     || colisao.gameObject.name == "Enemy03") && this.name == "Booster" && !moeda && this.transform.position.x < 7) {
			animator = moedaT.GetComponent<Animator> ();
			animator.SetBool ("Colidiu", true);
			moeda = true;
		}
	}

	void pegouMoeda()
	{
		if (moeda == true) 
		{
			count += Time.deltaTime;
			if (count > 0.2f)
			{
				alpha.color = new Color (1f, 1f, 1f, 0f);
				moeda = false;
				count = 0;
			}
		}
	}
}
