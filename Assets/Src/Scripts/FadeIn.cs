using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public GameObject fade;

	public float speed;
	private float alpha = 1;
	private float red = 0;
	private float green = 0;
	private float blue = 0;

	SpriteRenderer _renderer;
	// Use this for initialization
	void Start () {
		
		transform.position = new Vector3 (0,0,9);
		
		_renderer = this.GetComponent<SpriteRenderer> ();
		_renderer.color = new Color (red, green, blue, alpha);
		
	}
	
	// Update is called once per frame
	void Update () {
		

		if (_renderer.color.a > 0) {
			
			transform.position = new Vector3 (0,0,-5);
			_renderer.color = new Color(red, green, blue, alpha - speed);
			speed += 0.9f * Time.deltaTime;
		}

		if (_renderer.color.a <= 0) 
		{
			Destroy(gameObject);

		}
		
	}
}