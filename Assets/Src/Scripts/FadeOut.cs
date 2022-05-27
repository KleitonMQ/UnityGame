using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

	public GameObject fade;


	public float speed;
	private float alpha = 0;
	private float red = 0;
	private float green = 0;
	private float blue = 0;
	public float animationDelay;
	public float count;
	public float introDelay = 0;

	SpriteRenderer _renderer;

	// Use this for initialization
	void Start () {

		transform.position = new Vector3 (0,0,3);

		_renderer = this.GetComponent<SpriteRenderer> ();
		_renderer.color = new Color (red, green, blue, alpha);

	}
	
	// Update is called once per frame
	void Update () {

		count = Deadh.timeFade();

		introDelay = Introducao.fade;

		animationDelay = Btn_Menu.CountFade ();

		if (animationDelay < -1) {

			transform.position = new Vector3 (0,0,-5);
			_renderer.color = new Color(red, green, blue, alpha + speed);
			speed += 2f * Time.deltaTime;
		}


		
		if (count > 60) {
			
			transform.position = new Vector3 (0,0,-5);
			_renderer.color = new Color(red, green, blue, alpha + speed);
			speed += 2f * Time.deltaTime;
		}
		if (introDelay < -1) {
			transform.position = new Vector3 (0,0,-5);
			_renderer.color = new Color(red, green, blue, alpha + speed);
			speed += 2f * Time.deltaTime;
		}
	}
}
