using UnityEngine;
using System.Collections;

public class Sons : MonoBehaviour {
	public bool audio2;
	public bool audio3;
	public string fase;
	// Use this for initialization
	void Start () {

		if (this.name == "Main Camera") 
		{
			GetComponent<AudioSource>().Play ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		fase = SpawnGroundF1.faseInfo;
		if (fase == "FASE02" && this.name == "Main Camera") 
		{
			GetComponent<AudioSource>().Stop();
		}
		if (fase == "FASE02" && !audio2 && this.name == "Player") 
		{
			GetComponent<AudioSource>().Play();
			audio2 = true;
		}
		if (fase == "FASE03" && !audio3 && this.name == "Hud") 
		{
			GetComponent<AudioSource>().Play();
			audio3 = true;
		}
		if (fase == "FASE03" && this.name == "Player") 
		{
			GetComponent<AudioSource>().Stop();
		}
	}
}
