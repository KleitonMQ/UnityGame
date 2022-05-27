using UnityEngine;
using System.Collections;

public class Btn_Menu : MonoBehaviour {

	public static bool isTouch = false;
	public Transform btn;
	private Animator animator;
	private static float animationDelay = 1.5f;
	private static bool firstTime = true;
	private bool canToch = true;

	void Start () {

		animator = btn.GetComponent<Animator>();
		animationDelay = 1.5f;
		isTouch = false;
		canToch = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (isTouch) {

			animationDelay -= Time.deltaTime;	
		}

		if (this.animator.name == "btnExit" && animationDelay < - 2.5 && !canToch) {
			Application.Quit();
		}
		if (this.animator.name == "btnContinue" && animationDelay < - 2.5 && !canToch) {

			Deadh.morto = false;
			isTouch = false;
			animationDelay = 1.5f;
			Application.LoadLevel ("sobre");

		}

		if (this.gameObject.name == "BtnVoltar" && !canToch) {
			
			Deadh.morto = false;
			isTouch = false;
			animationDelay = 1.5f;
			Application.LoadLevel ("menu");
			
		}

		if (this.animator.name == "btnStart" && animationDelay < - 2.5 && !canToch) {
			Deadh.morto = false;
			isTouch = false;
			animationDelay = 1.5f;
			if (firstTime){firstTime = false; Application.LoadLevel ("intro");}
			else{Application.LoadLevel ("fase1");}
		}
		
	}
	void OnMouseUp()
	{
		if (!isTouch) {
			animator.SetTrigger("touch");
			isTouch = true;
			canToch = false;
		}
	}
	
	void OnMouseDown()
	{

	}
	public static float CountFade()
	{
		return animationDelay;
	}

}
