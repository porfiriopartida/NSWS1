using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	bool over;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool clicked = Input.GetMouseButtonDown (0);
		if (clicked) {
			print ("Clicked: ");
		}
		if (clicked && over)
		{
			startGame();
		}
	}
	
	
	private void startGame()
	{
		//Reset score
		PlayerPrefs.SetInt("score", 0);
		PlayerPrefs.SetInt("Current", 1);
		PlayerPrefs.SetInt("currentHP", 100);
		//		Application.LoadLevel("intro");
		//Loads intro, or lv 1 for now.
		Application.LoadLevel("Level1");
	}

	void OnMouseEnter()
	{
		print ("Mouse enter");
		over = true;
	}
	
	void OnMouseExit()
	{
		over = false;
	}
}
