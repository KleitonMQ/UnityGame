using UnityEngine;
using System.Collections;

public class BehaviourLight : MonoBehaviour {

	public Rigidbody2D anguloLuz;
	private float giro;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		giro += -800f * Time.deltaTime;
		anguloLuz.MoveRotation (giro);
	}
}
