using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogManager : MonoBehaviour {
	
	public Text text;
	// Use this for initialization
	void Start () {
		HudManager.TEXT = text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
