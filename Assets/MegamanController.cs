using UnityEngine;
using System.Collections;

public class MegamanController : MonoBehaviour {
	public Animator MyAnimator;
	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator>();
	}
	bool facingRight = true;
	// Update is called once per frame
	void Update () {
		float hVal = Input.GetAxis ("Horizontal");
		bool isHorizontal = hVal != 0;

		if (hVal > 0 && !facingRight || hVal < 0 && facingRight){
			switchSide();
		}
		MyAnimator.SetBool("isRunning", isHorizontal);
	}
	void switchSide(){
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
	}
}
