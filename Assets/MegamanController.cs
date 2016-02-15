using UnityEngine;
using System.Collections;

public class MegamanController : MonoBehaviour {
	public Animator MyAnimator;
	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		bool isHorizontal = Input.GetAxis ("Horizontal") > 0.2;
		MyAnimator.SetBool("isRunning", isHorizontal);
	}
}
