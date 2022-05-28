using UnityEngine;
using System.Collections;

public class TouchDown : MonoBehaviour {

	private float count;
	public float contTriger;
	public float speed;

	public byte emTransicao;

	public Transform player;
	public Transform playerO;

	public bool touch;
	public bool isGrounded;
	public bool touchOn;
	public bool toqueChave;
	public Transform ground;
	public BoxCollider2D playerBox;
	public CircleCollider2D playerCircle;

	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = player.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		isGrounded = Physics2D.Linecast (player.transform.position, ground.position, 1 << LayerMask.NameToLayer ("Plataforma"));
		if (touchOn && Touch.ModoControle == "Correr") 
		{
			touch = true;
			touchOn = false;
		}
		if (isGrounded && Touch.ModoControle == "Correr") 
		{
			count++;
		}
		if (!isGrounded && Touch.ModoControle == "Correr") 
		{
			count = 0;
		}
		if (playerBox.isTrigger && playerCircle.isTrigger && touch  && Touch.ModoControle == "Correr") 
		{
			contTriger += Time.deltaTime;
			if (contTriger > 0.3f)
			{
				touch = false;
				playerBox.isTrigger = false;
				contTriger = 0;
			}
				
		}

		//MODO DE VOO

		if (Touch.ModoControle == "Fly" & !Deadh.morto) 
		{
			touchOn = true;
			//touch = false;
			contTriger += Time.deltaTime;
			if ((touch && playerO.position.y == 2f && toqueChave) || emTransicao == 1)
			{
				toqueChave = false;
				emTransicao = 1;
				playerO.eulerAngles = new Vector3(0,0, -45);
				playerO.position -= new Vector3(0, 1 * speed * Time.deltaTime, 0);
				if (playerO.position.y <= 0f)
				{
					touch = false;
					playerO.position = new Vector3(playerO.position.x, 0f, 0);
					playerO.eulerAngles = new Vector3(0,0, -15);
					emTransicao = 0;
					toqueChave = true;
				}
			}
			if ((touch && player.position.y == 0f && toqueChave) || emTransicao == 2)
			{
				toqueChave = false;
				emTransicao = 2;
				playerO.eulerAngles = new Vector3(0,0, -45);
				playerO.position -= new Vector3(0, 1 * speed * Time.deltaTime, 0);
				if (playerO.position.y <= -2.1f)
				{
					touch = false;
					playerO.position = new Vector3(playerO.position.x, -2.1f, 0);
					playerO.eulerAngles = new Vector3(0,0, -15);
					emTransicao = 0;
					toqueChave = true;
				}
			}
		}

	}

	void OnMouseUp()
	{
		
	}
	
	void OnMouseDown()
	{
		if (player.position.y > -2 && isGrounded && count > 3  && Touch.ModoControle == "Correr") 
		{
			playerBox.isTrigger = true;
			playerCircle.isTrigger = true;
			animator.SetBool("fall", true);
			animator.SetBool("jump", false);
			animator.SetBool("ground", false);
			touch = true;
		}
		if (Touch.ModoControle == "Fly") 
		{
			if (contTriger > 0.5f && playerO.position.y > -1.9f)
			{
				touch = true;
				contTriger = 0;
				toqueChave = true;
			}
		}
	}
}
