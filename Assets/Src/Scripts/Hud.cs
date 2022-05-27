using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour {

	public GameObject[] uniC;
	public GameObject[] dezC;
	public GameObject[] cenC;
	public GameObject[] milC;

	public GameObject[] uniK;
	public GameObject[] dezK;
	public GameObject[] cenK;
	public GameObject[] milK;

	public GameObject[] M1;
	public GameObject[] M2;
	public GameObject[] M3;
	public GameObject[] M4;
	public GameObject[] M5;
	public GameObject[] M6;
	public GameObject[] M7;
	public GameObject[] M8;
	public GameObject[] M9;

	public static byte contadorUC;
	public static byte contadorDC;
	private byte contadorCC;
	private byte contadorMC;
	
	public static byte contadorUK;
	public static byte contadorDK;
	private byte contadorCK;
	private byte contadorMK;

	private float contadorM;
	private byte contadorM1;
	private byte contadorM2;
	private byte contadorM3;
	private byte contadorM4;
	private byte contadorM5;
	private byte contadorM6;
	private byte contadorM7;
	private byte contadorM8;
	private byte contadorM9;

	void Start () {

		contadorUK = 0; contadorDK = 0; contadorDC = 0; contadorUC = 0;

		// CONTROLE HUD C;
		for (byte i = 0; i < uniC.Length; i++) 
		{
			uniC[i].SetActive(false);
		}

		for (byte i = 0; i < dezC.Length; i++) 
		{
			dezC[i].SetActive(false);
		}

		for (byte i = 0; i < cenC.Length; i++) 
		{
			cenC[i].SetActive(false);
		}

		for (byte i = 0; i < milC.Length; i++) 
		{
			milC[i].SetActive(false);
		}

		// CONTROLE HUD K;
		for (byte i = 0; i < uniK.Length; i++) 
		{
			uniK[i].SetActive(false);
		}
		
		for (byte i = 0; i < dezK.Length; i++) 
		{
			dezK[i].SetActive(false);
		}
		
		for (byte i = 0; i < cenK.Length; i++) 
		{
			cenK[i].SetActive(false);
		}

		for (byte i = 0; i < milK.Length; i++) 
		{
			milK[i].SetActive(false);
		}

		// CONTROLE HUD M
		for (byte i = 0; i < M1.Length; i++) 
		{
			M1[i].SetActive(false);
		}
		
		for (byte i = 0; i < M2.Length; i++) 
		{
			M2[i].SetActive(false);
		}
		
		for (byte i = 0; i < M3.Length; i++) 
		{
			M3[i].SetActive(false);
		}
		for (byte i = 0; i < M4.Length; i++) 
		{
			M4[i].SetActive(false);
		}
		
		for (byte i = 0; i < M5.Length; i++) 
		{
			M5[i].SetActive(false);
		}
		
		for (byte i = 0; i < M6.Length; i++) 
		{
			M6[i].SetActive(false);
		}
		for (byte i = 0; i < M7.Length; i++) 
		{
			M7[i].SetActive(false);
		}
		
		for (byte i = 0; i < M8.Length; i++) 
		{
			M8[i].SetActive(false);
		}

		for (byte i = 0; i < M9.Length; i++) 
		{
			M9[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		//BLOCO M
		contadorM += 50 * Time.deltaTime;
		if (contadorM > 5) 
		{
			contadorM1++;
			contadorM = 0;
		}
		if (contadorM1 > 9) 
		{
			contadorM2++;
			contadorM1 = 0;
		}
		if (contadorM2 > 9) 
		{
			contadorM3++;
			contadorM2 = 0;
		}
		if (contadorM3 > 9) 
		{
			contadorM4++;
			contadorM3 = 0;
		}
		if (contadorM4 > 9) 
		{
			contadorM5++;
			contadorM4 = 0;
		}
		if (contadorM5 > 9) 
		{
			contadorM6++;
			contadorM5 = 0;
		}
		if (contadorM6 > 9) 
		{
			contadorM7++;
			contadorM6 = 0;
		}
		if (contadorM7 > 9) 
		{
			contadorM8++;
			contadorM7 = 0;
		}
		if (contadorM8 > 9) 
		{
			contadorM9++;
			contadorM8 = 0;
		}

		//BLOCO C


		if (contadorUC > 9) 
		{
			contadorDC++;
			contadorUC = 0;
		}
		if (contadorDC > 9) 
		{
			contadorCC++;
			contadorDC = 0;
		}
		if (contadorCC > 9) 
		{
			contadorMC++;
			contadorCC = 0;
		}

		//BLOCO K
		
		
		if (contadorUK > 9) 
		{
			contadorDK++;
			contadorUK = 0;
		}

		if (contadorDK > 9) 
		{
			contadorCK++;
			contadorDK = 0;
		}

		if (contadorCK > 9) 
		{
			contadorMK++;
			contadorCK = 0;
		}

		//ATUALIZA C
		for (byte i = 0; i < uniC.Length; i++) 
		{
			uniC[i].SetActive(false);
			if (i == contadorUC)
			{
				uniC[i].SetActive(true);
			}
		}
		
		for (byte i = 0; i < dezC.Length; i++) 
		{
			dezC[i].SetActive(false);
			if (i == contadorDC)
			{
				dezC[i].SetActive(true);
			}
		}
		
		for (byte i = 0; i < cenC.Length; i++) 
		{
			cenC[i].SetActive(false);
			if (i == contadorCC)
			{
				cenC[i].SetActive(true);
			}
		}
		for (byte i = 0; i < milC.Length; i++) 
		{
			milC[i].SetActive(false);
			if (i == contadorCC)
			{
				milC[i].SetActive(true);
			}
		}
	
		//ATUALIZA K

		for (byte i = 0; i < uniK.Length; i++) 
		{
			uniK[i].SetActive(false);
			if (i == contadorUK)
			{
				uniK[i].SetActive(true);
			}
		}
		
		for (byte i = 0; i < dezK.Length; i++) 
		{
			dezK[i].SetActive(false);
			if (i == contadorDK)
			{
				dezK[i].SetActive(true);
			}
		}
		
		for (byte i = 0; i < cenK.Length; i++) 
		{
			cenK[i].SetActive(false);
			if (i == contadorCK)
			{
				cenK[i].SetActive(true);
			}
		}

		for (byte i = 0; i < milK.Length; i++) 
		{
			milK[i].SetActive(false);
			if (i == contadorMK)
			{
				milK[i].SetActive(true);
			}
		}
		//ATUALIZA M

		for (byte i = 0; i < M1.Length; i++) 
		{
			M1[i].SetActive(false);
			if (i == contadorM1)
			{
				M1[i].SetActive(true);
			}
		}
		
		for (byte i = 0; i < M2.Length; i++) 
		{
			M2[i].SetActive(false);
			if (i == contadorM2)
			{
				M2[i].SetActive(true);
			}
		}
		
		for (byte i = 0; i < M3.Length; i++) 
		{
			M3[i].SetActive(false);
			if (i == contadorM3)
			{
				M3[i].SetActive(true);
			}
		}
		for (byte i = 0; i < M4.Length; i++) 
		{
			M4[i].SetActive(false);
			if (i == contadorM4)
			{
				M4[i].SetActive(true);
			}
		}
		
		for (byte i = 0; i < M5.Length; i++) 
		{
			M5[i].SetActive(false);
			if (i == contadorM5)
			{
				M5[i].SetActive(true);
			}
		}
		
		for (byte i = 0; i < M6.Length; i++) 
		{
			M6[i].SetActive(false);
			if (i == contadorM6)
			{
				M6[i].SetActive(true);
			}
		}
		for (byte i = 0; i < M7.Length; i++) 
		{
			M7[i].SetActive(false);
			if (i == contadorM7)
			{
				M7[i].SetActive(true);
			}
		}
		
		for (byte i = 0; i < M8.Length; i++) 
		{
			M8[i].SetActive(false);
			if (i == contadorM8)
			{
				M8[i].SetActive(true);
			}
		}
		for (byte i = 0; i < M9.Length; i++) 
		{
			M9[i].SetActive(false);
			if (i == contadorM8)
			{
				M9[i].SetActive(true);
			}
		}
	}
}
