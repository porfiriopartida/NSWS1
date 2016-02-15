using UnityEngine;
using System.Collections;

public class MegamanController : MonoBehaviour {
	public Animator MyAnimator;
	public Rigidbody2D MyRigidbody;
	public float MovementSpeed = 1f;
	public float JumpForce = 10f;
	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator>();
		MyRigidbody = GetComponent<Rigidbody2D>();
	}
	bool facingRight = true;
	bool isGrounded = true;
	// Update is called once per frame
	void Update () {
		//float hVal = Input.GetAxis ("Horizontal");
		bool isJump = Input.GetButtonDown ( "Jump" );
		bool isLeft = Input.GetButton ( "Left" );
		bool isRight = Input.GetButton ( "Right" );
		bool isDashing = Input.GetButton ( "Dash" );
		bool isShooting = Input.GetButton ( "Fire1" );
		bool isHorizontal = false;
		float hVal = 0;

		if (isRight) {
			hVal = 1;
		} else if (isLeft) {
			hVal = -1;
		}
		isHorizontal = hVal != 0;

		if(hVal != 0){
			MyRigidbody.velocity = new Vector2(hVal * MovementSpeed, MyRigidbody.velocity.y);
			if (hVal > 0 && !facingRight || hVal < 0 && facingRight){
				switchSide();
			}
		}

		if(isJump){
			MyRigidbody.AddForce(new Vector2(0, JumpForce));
			isGrounded = false;
		}
		
		MyAnimator.SetBool("isGrounded", isGrounded);
		MyAnimator.SetBool("isRunning", isHorizontal);
		MyAnimator.SetBool("isShooting", isShooting);
		MyAnimator.SetBool("isDashing", isDashing);
	}
	void switchSide(){
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
	}
}
