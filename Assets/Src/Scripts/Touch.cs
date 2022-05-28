using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {

	private bool tocou;
	public bool jumped;
	public bool isGrounded;
	private bool appForce;
	public bool isGrounded2;
	private bool iniciaTransicao;
	private bool gravityOn;

	public float force;
	public float contador;
	public float contadorColider;
	public float gravidade;
	private float countJump;
	public float countControle;
	public float speed;

	public byte emTransicao;

	public Transform ground;
	public Transform ground2;
	public Transform player;
	public Transform playerO;
	private Animator animator;
	public Transform enemyP;
	public BoxCollider2D playerBox;

	public Rigidbody2D rigid;
	public Transform gravity;

	public GameObject shadow;

	public static string ModoControle;
	public bool toqueChave;
	public static Transform enemyPS;
	public static Transform playerS;

	void Start(){

		enemyPS = enemyP;
		playerS = player;
		toqueChave = true;
		gravityOn = true;
		ModoControle = "Correr";
		appForce = true;
		animator = player.GetComponent<Animator> ();
		countControle = 0;
	}


	void Update()
	{
		TrocaControle ();
		AjustaAngulo ();
		if (ModoControle == "Correr" || ModoControle == "Estatico" && gravityOn) 
		{
			rigid.AddForce (transform.up * - gravidade * Time.deltaTime);
		}

		isGrounded = Physics2D.Linecast (player.transform.position, ground.position, 1
                       << LayerMask.NameToLayer ("Plataforma"));

		isGrounded2 = Physics2D.Linecast (player.transform.position, ground2.position, 1 << LayerMask.NameToLayer ("Plataforma"));

		if (isGrounded && isGrounded2 && jumped) 
		{
			shadow.GetComponent<SpriteRenderer>().color = new Color(0f,0f,255f,0.4f);
		}

		Pular ();
		if (!isGrounded && ModoControle == "Correr") 
		{
			countJump = 0;
			jumped = false;
		}
		if (isGrounded && contador == 0 && ModoControle == "Correr") 
		{
			countJump++;
			jumped = true;
		}


		//MODO DE VOO

		if (ModoControle == "Fly" && !Deadh.morto) 
		{
			countJump += Time.deltaTime;
			if ((tocou && playerO.position.y <= -2f && playerO.position.y >= -2.1f && toqueChave) || emTransicao == 2)
			{
				toqueChave = false;
				emTransicao = 2;
				playerO.eulerAngles = new Vector3 (0,0,0);
				playerO.position += transform.up * speed * Time.deltaTime;
				if (playerO.position.y >= 0f)
				{
					playerO.position = new Vector3(playerO.position.x, 0f, 0);
					playerO.eulerAngles = new Vector3 (0,0,-15);
					countJump = 0;
					tocou = false;
					emTransicao = 0;
					toqueChave = true;
				}
			}

			if ((tocou && playerO.position.y == 0f && toqueChave) || emTransicao == 1)
			{
				toqueChave = false;
				emTransicao = 1;
				playerO.eulerAngles = new Vector3 (0,0,0);
				playerO.position += transform.up * speed * Time.deltaTime;
				if (playerO.position.y >= 2f)
				{
					playerO.position = new Vector3(playerO.position.x, 2f, 0);
					playerO.eulerAngles = new Vector3 (0,0,-15);
					countJump = 0;
					tocou = false;
					emTransicao = 0;
					toqueChave = true;
				}
			}
			if (iniciaTransicao)
			{
				playerO.position += transform.up * speed * Time.deltaTime;
				playerO.eulerAngles -= new Vector3(0,0,100*Time.deltaTime);
				if (playerO.position.y >= 0f)
				{
					playerO.position = new Vector3(playerO.position.x, 0f, 0);
					playerO.eulerAngles = new Vector3(0,0,-15f);
					countJump = 0;
					tocou = false;
					iniciaTransicao = false;
				}
			}
		}
	}

	void OnMouseUp()
	{

	}

	void OnMouseDown()
	{
		if (countJump > 1f && ModoControle == "Correr")
		{
			tocou = true;
		}
		if (ModoControle == "Fly" && playerO.position.y != 2f)
		{
			tocou = true;
		}
	}

	private void Pular()
	{

		//condiçoes de salto.
		if (isGrounded2 && tocou && appForce && jumped && ModoControle == "Correr") 
		{

			rigid.AddForce(transform.up * (force));
			appForce = false;
			jumped = false;
			playerBox.isTrigger = true;
			
		}

		if (tocou && !appForce && ModoControle == "Correr") {

			contador += Time.deltaTime;
			enemyP.position += new Vector3(0.2f*Time.deltaTime, 0, 0);
			if (contador > 0.45f)
			{
				appForce = true;
				playerBox.isTrigger = false;
				tocou = false;
				contador = 0;
			}
		}

		//Condiçoes de animaçao
		if (ModoControle == "Correr") 
		{
			animator.SetBool ("fly", false);
			if (contador <= 0 && !isGrounded || playerBox.isTrigger)
			{
				animator.SetBool ("fall", true);
				animator.SetBool ("jump", false);
				animator.SetBool ("ground", false);
				shadow.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 255f, 0f);
			}

			if (contador > 0) 
			{
				animator.SetBool ("fall", false);
				animator.SetBool ("jump", true);
				animator.SetBool ("ground", false);
				shadow.GetComponent<SpriteRenderer> ().color = new Color (0f, 0f, 255f, 0f);
			}

			if (contador <= 0 && isGrounded && !playerBox.isTrigger) 
			{
				contador = 0;
				animator.SetBool ("fall", false);
				animator.SetBool ("jump", false);
				animator.SetBool ("ground", true);
			}
		}
		if (ModoControle == "Fly") 
		{
			animator.SetBool ("fly", true);
		}
		if (ModoControle == "Estatico") 
		{
			if (isGrounded2 && !playerBox.isTrigger) 
			{
				contador = 0;
				animator.SetBool ("fall", false);
				animator.SetBool ("jump", false);
				animator.SetBool ("ground", true);
			}
		}
	}
	void TrocaControle()
	{
		if (ModoControle == "Estatico") 
		{
			playerBox.isTrigger = false;
			countControle += Time.deltaTime;
			if (countControle > 2f)
			{
				rigid.gravityScale = 0;
				gravityOn = false;
			}
			if (countControle > 3f)
			{
				ModoControle = "Fly";
				countControle = 0;
				iniciaTransicao = true;
			}
		}
	}
	void AjustaAngulo()
	{
		if (player.transform.rotation.z != 0 && ModoControle == "Correr") 
		{
			gravityOn = true;
			rigid.gravityScale = 1;
			playerO.position += transform.up * (speed*3) * Time.deltaTime;
			playerO.eulerAngles += new Vector3(0,0,100*Time.deltaTime);
			if (player.transform.rotation.z > 0)
			{
				playerO.eulerAngles = new Vector3(0,0,0);
				tocou = true;
			}
		}
	}
}