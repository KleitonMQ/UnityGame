using UnityEngine;
using System.Collections;

public class CamControler : MonoBehaviour {

	public Transform player;
	public Transform btnUP;
	public Transform btnDown;
	public Transform hud;
	public Transform fade;
	public Transform backGround;
	public Transform EnemyP;

	private float btnUpPosition;
	private float btnDownPosition;
	private float hudPosition;
	private float fadePosition;
	private float backGroundPosition;
	private float playerPosition;
	private float EnemyPPosition;

	// Use this for initialization
	void Start () {
		btnUpPosition = btnUP.position.y - this.transform.position.y;
		btnDownPosition = btnDown.position.y - this.transform.position.y;
		hudPosition = hud.position.y - this.transform.position.y;
		fadePosition = fade.position.y - this.transform.position.y;
		backGroundPosition = backGround.position.y - this.transform.position.y;
		playerPosition = 2.368f - this.transform.position.y;
		EnemyPPosition = EnemyP.position.y - this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 newPosition = new Vector3 (this.transform.position.x, player.position.y - playerPosition , this.transform.position.z);
		if (player.position.y > 2.368 && !Deadh.morto)
		{
			this.transform.position = newPosition;
			btnUP.position = new Vector3 (btnUP.position.x, this.transform.position.y + btnUpPosition, btnUP.position.z);
			btnDown.position = new Vector3 (btnDown.position.x, this.transform.position.y + btnDownPosition, btnDown.position.z);
			hud.position = new Vector3 (hud.position.x, this.transform.position.y + hudPosition, hud.position.z);
			fade.position = new Vector3 (fade.position.x, this.transform.position.y + fadePosition, fade.position.z);
			backGround.position = new Vector3 (backGround.position.x, this.transform.position.y + backGroundPosition, backGround.position.z);
			EnemyP.position = new Vector3(EnemyP.position.x, this.transform.position.y + EnemyPPosition, EnemyP.position.z);

		}

		if (player.position.y < 2.368 && this.transform.position.y > 0 && !Deadh.morto)
		{
			this.transform.position = Vector3.Lerp (this.transform.position, new Vector3(0,0,this.transform.position.z), 1f);
			btnUP.position = new Vector3 (btnUP.position.x, this.transform.position.y + btnUpPosition, btnUP.position.z);
			btnDown.position = new Vector3 (btnDown.position.x, this.transform.position.y + btnDownPosition, btnDown.position.z);
			hud.position = new Vector3 (hud.position.x, this.transform.position.y + hudPosition, hud.position.z);
			fade.position = new Vector3 (fade.position.x, this.transform.position.y + fadePosition, fade.position.z);
			backGround.position = new Vector3 (backGround.position.x, this.transform.position.y + backGroundPosition, backGround.position.z);
			EnemyP.position = new Vector3(EnemyP.position.x, this.transform.position.y + EnemyPPosition, EnemyP.position.z);
		}
		/*
		if ((player.position.y < 2.41f && player.position.y > 2.33f))
		{
			this.transform.position = Vector3.Lerp (this.transform.position, new Vector3(0,2.397132f,this.transform.position.z), 1f);
			btnUP.position = new Vector3 (btnUP.position.x, this.transform.position.y + btnUpPosition, btnUP.position.z);
			btnDown.position = new Vector3 (btnDown.position.x, this.transform.position.y + btnDownPosition, btnDown.position.z);
			hud.position = new Vector3 (hud.position.x, this.transform.position.y + hudPosition, hud.position.z);
			fade.position = new Vector3 (fade.position.x, this.transform.position.y + fadePosition, fade.position.z);
			backGround.position = new Vector3 (backGround.position.x, this.transform.position.y + backGroundPosition, backGround.position.z);
		}*/
	}
}
