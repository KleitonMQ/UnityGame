using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public GameObject enemy;
	public Transform limite;
	public GameObject player;

	public bool colidiu;

	public float speed;
	public float speedP;
	public int count = 0;
	public string fase;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		fase = SpawnGroundF1.faseInfo;

		if (enemy.name == "Enemy02") 
		{
			enemy.transform.position += new Vector3 (90f*speed*Time.deltaTime, 0, 0);
			if (count > 0)
			{
				count -= 1;
			}

			if (count < 1)
			{
				colidiu = Physics2D.Linecast (enemy.transform.position, limite.position, 1 << LayerMask.NameToLayer ("Limite"));
			}
			if (colidiu)
			{
				count = 30;
				speed *= -1;
				if(speed < 0)
				{
					enemy.transform.eulerAngles = new Vector2(0, 0);
				}
				if(speed > 0)
				{
					enemy.transform.eulerAngles = new Vector2(0, 180);
				}
				colidiu = false;

			}

		}


		if (this.tag == "Enemy03")
		{
			if (enemy.transform.position.x < 10)
			{
				enemy.transform.position += new Vector3 ((SpawnGroundF1.speedFase - 0.5f) * Time.deltaTime , 0, 0);
			}
			if (enemy.transform.position.x >= 10 && fase == "TRANSICAO")
			{
				enemy.transform.position += new Vector3 ((SpawnGroundF1.speedFase - 1.5f) * Time.deltaTime, 0, 0);
			}
			if (enemy.transform.position.x < -10)
			{
				this.gameObject.SetActive(false);
			}
		}

		if (enemy.name == "EnemyP") 
		{
			if (fase == "FASE02" && (this.transform.position.x <= -9.22))
			{
				enemy.transform.position += new Vector3 (5 * Time.deltaTime, 0, 0);
				
			}
		}
	}
}
