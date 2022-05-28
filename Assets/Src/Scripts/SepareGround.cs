using UnityEngine;
using System.Collections;

public class SepareGround : MonoBehaviour {

	public float velSeparacao;

	public bool sobreposto;


	public Transform pontoSobreposto;
	public Transform plataforma;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		sobreposto = Physics2D.Linecast(this.transform.position, pontoSobreposto.transform.position, 1 << LayerMask.NameToLayer("Plataforma"));

		if (sobreposto) 
		{
			plataforma.transform.position += new Vector3 (velSeparacao, 0, 0) * Time.deltaTime;
		}
	
	}
}
