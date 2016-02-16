using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MegamanController : MonoBehaviour {
	public Animator MyAnimator;
	public Rigidbody2D MyRigidbody;
	public float MovementSpeed = 1f;
	public float JumpForce = 10f;                 // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask WhatIsGround;
	[SerializeField] private Transform GroundCheck; 
	float groundCheckRadius = 0.02f;
	public Text score;
	public Slider healthBar;
	private int currentHP = 100;
	BoxCollider2D MyCollider;
	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator>();
		MyRigidbody = GetComponent<Rigidbody2D>();
		MyCollider =  GetComponent<BoxCollider2D>();
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
		bool isWounded = false; 

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

		if(isGrounded && isJump){
			MyRigidbody.AddForce(new Vector2(0, JumpForce));
			isGrounded = false;
		}
		isGrounded = Physics2D.OverlapCircle (GroundCheck.position, groundCheckRadius, WhatIsGround);

		healthBar.value = currentHP;
		MyAnimator.SetBool("isGrounded", isGrounded);
		MyAnimator.SetBool("isRunning", isHorizontal);
		MyAnimator.SetBool("isShooting", isShooting);
		MyAnimator.SetBool("isDashing", isDashing);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		//Destroy(this.transform.parent.gameObject);
	}

	void switchSide(){
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
	}
}
