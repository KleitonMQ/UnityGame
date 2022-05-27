using UnityEngine;
using System.Collections;

public class BGTransicao : MonoBehaviour {


	public static string gatilho;

	private byte BG;
	public byte BGN;


	public float speed;

	private bool saida;

	SpriteRenderer _renderer;

	// Use this for initialization
	void Start () {
		BG = 1;
		_renderer = this.GetComponent<SpriteRenderer> ();
		_renderer.color = new Color (1, 1, 1, 0);
		gatilho = null;
	}
	

	void Update () {

		if ( gatilho == "TRANSICAO") 
		{

			if (_renderer.color.a < 0.5f && BG == BGN) {
				
				_renderer.color = new Color(1, 1, 1, 0 + speed);
				speed += 0.5f * Time.deltaTime;
				if (_renderer.color.a >= 0.5f)
				{
					speed = 0;
				}
			}
			/*if (this.transform.position.y > 0 && this.transform.rotation.x >= 0)
			{
				transform.Rotate(Vector3.left *30* Time.deltaTime);
			}
			
		if (this.transform.position.y < 0 && this.transform.rotation.x >= 0)
			{
				transform.Rotate(Vector3.left * 30* Time.deltaTime);
			}
			saida = true; */
		}

		if (gatilho == "FASE") 
		{
			if (_renderer.color.a > 0f && BG == BGN) {
				
				_renderer.color = new Color(1, 1, 1, 0.5f - speed);
				speed += 0.5f * Time.deltaTime;
				if (_renderer.color.a <=0)
				{
					Destroy(this);
					gatilho = null;
					BG++;
				}
			}
			/*
			if (this.transform.position.y > 0 && this.transform.rotation.x < 90)
			{
				transform.Rotate(Vector3.right *30* Time.deltaTime);
			}
			
			if (this.transform.position.y < 0 && this.transform.rotation.x < 90)
			{
				transform.Rotate(Vector3.right * 30* Time.deltaTime);
			}
			if (this.transform.eulerAngles.x > 90)
			{
				Destroy(this.gameObject);
			}*/
		}
	}
}
