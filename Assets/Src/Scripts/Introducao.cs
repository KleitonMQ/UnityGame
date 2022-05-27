using UnityEngine;
using System.Collections;

public class Introducao : MonoBehaviour {

	public GameObject[] tela;
	public BoxCollider2D toqueTela;

	private float count;
	public static float fade;
	public static bool encerra;
	// Use this for initialization
	void Start () {

		encerra = false;
		for (int i =0; i < tela.Length; i++) 
		{
			tela[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;

		if (count > 2f && count < 100) 
		{
			tela[0].SetActive(true);

		}
		if (count > 2.5f && count < 100) 
		{
			tela[1].SetActive(true);
		}
		if (count > 3f && count < 100) 
		{
			tela[2].SetActive(true);
		}
		if (count > 3.5f && count < 100) 
		{
			tela[3].SetActive(true);
		}

		if (count > 4f && count < 100) 
		{
			tela[4].SetActive(true);
		}
		if (count > 4.2f && count < 100) 
		{
			tela[5].SetActive(true);
		}
		if (count > 4.4f && count < 100) 
		{
			tela[6].SetActive(true);
		}
		if (count > 4.5f && count < 100) 
		{
			tela[7].SetActive(true);
		}
		if (count > 4.6f && count < 100) 
		{
			tela[8].SetActive(true);
		}
		if (count > 4.7f && count < 100) 
		{
			tela[9].SetActive(true);
		}
		if (count > 4.8f && count < 100) 
		{
			tela[10].SetActive(true);
		}
		if (count > 4.9f && count < 100) 
		{
			tela[11].SetActive(true);
		}
		if (count > 5f && count < 100) 
		{
			tela[12].SetActive(true);
		}
		if (count > 5.1f && count < 100) 
		{
			tela[13].SetActive(true);
		}
		if (count > 5.2f && count < 100) 
		{
			tela[14].SetActive(true);
			count = 100;
		}
		if (count > 101) 
		{
			for (int i = 0; i < tela.Length; i++)
			{
				tela[i].SetActive(false);
			}
		}
		if (count > 107) { fade = -2f;}
		if (count > 109 || encerra) { fade = 0; Application.LoadLevel ("fase1"); }
	}
}
