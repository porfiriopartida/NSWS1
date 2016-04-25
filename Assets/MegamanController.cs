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
	float groundCheckRadius = 0.12f;
	private Text scoreText;
	private Slider healthBar;
	private int currentHP = 100;
	private int score = 0;
	BoxCollider2D MyCollider;
	AudioSource jumpAudio;   
	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator>();
		MyRigidbody = GetComponent<Rigidbody2D>();
		MyCollider =  GetComponent<BoxCollider2D>();
		scoreText = GameObject.FindGameObjectWithTag ("HUD_SCORE").GetComponent<Text>();
		healthBar = GameObject.FindGameObjectWithTag ("HUD_HEALTH_BAR").GetComponent<Slider>();

		jumpAudio = GetComponent<AudioSource> ();
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
			jumpAudio.Play ();
			MyRigidbody.AddForce(new Vector2(0, JumpForce));
			isGrounded = false;
		}
		isGrounded = Physics2D.OverlapCircle (GroundCheck.position, groundCheckRadius, WhatIsGround);
		
		if(healthBar != null){
			healthBar.value = currentHP;
		}
		if(scoreText != null){
			scoreText.text = "Score: " + score;
		}
		//
		MyAnimator.SetBool("isGrounded", isGrounded);
		MyAnimator.SetBool("isRunning", isHorizontal);
		MyAnimator.SetBool("isShooting", isShooting);
		MyAnimator.SetBool("isDashing", isDashing);
	}
	
	//void OnTriggerEnter2D(Collider2D other)
	//{
		//print (other.transform.ToString());
		//this.score++;
	//}
	public void addScore(int v){
		this.score += 1;
	}

	void switchSide(){
		facingRight = !facingRight;
		transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
	}
	public bool isFacingRight(){
		return this.facingRight;
	}
}
