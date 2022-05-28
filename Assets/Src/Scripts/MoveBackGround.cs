using UnityEngine;
using System.Collections;

public class MoveBackGround : MonoBehaviour {

	public SpriteRenderer spriteRenderBG;
	public float red, green, blue, alfa;
	private float contador;
	public string fase;
	void Start()
	{
		red = spriteRenderBG.color.r;
		green = spriteRenderBG.color.g;
		blue = spriteRenderBG.color.b;
		alfa = spriteRenderBG.color.a;
		contador = 0;
	}
	// Update is called once per frame
	void Update () {
		fase = SpawnGroundF1.faseInfo;
		spriteRenderBG.color = new Color (red, green, blue, alfa);

		if (fase == "FASE02") 
		{
			spriteRenderBG.color = new Color (red, green, blue, alfa);
			contador += Time.deltaTime;
			if (contador > 1)
			{
				red -= 0.1f;
				if (red < 0)
				{
					red = 0;
				}

				green += 0.1f;
				if (green > 1)
				{
					green = 1;
				}

				blue -= 0.1f;
				if (blue < 0)
				{
					blue = 0;
				}
				contador = 0;
			}
		}

		if (fase == "FASE03") 
		{
			spriteRenderBG.color = new Color (red, green, blue, alfa);
			contador += Time.deltaTime;
			if (contador > 1)
			{
				red += 0.1f;
				if (red > 1)
				{
					red = 1;
				}
				
				green -= 0.1f;
				if (green < 0)
				{
					green = 0;
				}
				
				blue -= 0.1f;
				if (blue < 0)
				{
					blue = 0;
				}
				contador = 0;
			}
		}
	}
}
