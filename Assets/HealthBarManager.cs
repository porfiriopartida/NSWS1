using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour {
	
	public Slider healthBar;
	// Use this for initialization
	void Start () {
		HudManager.HEALTH_BAR = healthBar;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
