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
	AudioSource[] audioSources;
	AudioSource jumpAudio;
	AudioSource explosionAudio;
	Transform origin;
	// Use this for initialization
	void Start () {
		MyAnimator = GetComponent<Animator>();
		MyRigidbody = GetComponent<Rigidbody2D>();
		MyCollider =  GetComponent<BoxCollider2D>();
		scoreText = GameObject.FindGameObjectWithTag ("HUD_SCORE").GetComponent<Text>();
		healthBar = GameObject.FindGameObjectWithTag ("HUD_HEALTH_BAR").GetComponent<Slider>();
		
		audioSources = GetComponents<AudioSource> ();
		jumpAudio = audioSources [0];
		explosionAudio = audioSources [1];

		
		origin = GameObject.FindGameObjectWithTag ("START_POINT").transform;
		revive ();
	}
	public void die(){
		playSound (explosionAudio);
		canMove = false;
		canBeDamaged = false;
		canShoot = false;
		//die.
		MyAnimator.SetBool("isDamaged", false);
		MyAnimator.SetBool ("isDying", true);
		MyRigidbody.isKinematic = true;
	}
	public void revive(){
		canMove = true;
		canBeDamaged = true;
		canShoot = true;
		currentHP = 100;
		transform.position = origin.position;
		MyRigidbody.isKinematic = false;
		//die.
		MyAnimator.SetBool("isDamaged", false);
		MyAnimator.SetBool ("isDying", false);
	}
	bool facingRight = true;
	bool isGrounded = true;
	bool canMove = true, canBeDamaged = true, canShoot = true;
	float nextCanMove = 0;
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

		if(canMove && hVal != 0){
			MyRigidbody.velocity = new Vector2(hVal * MovementSpeed, MyRigidbody.velocity.y);
			if (hVal > 0 && !facingRight || hVal < 0 && facingRight){
				switchSide();
			}
		}

		if(canMove && isGrounded && isJump){
			playSound(jumpAudio);
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
		if(transform.position.y < -10){
			die ();
		}
	}
	IEnumerator shootingDelay(float waitTime){
		float endTime = Time.time + waitTime;
		yield return new WaitForSeconds(waitTime);
		canShoot = true;
	}
	

	public void shooting(){
		canShoot = false;
		StartCoroutine(shootingDelay(1F));
	}
	void playSound(AudioSource playable){
		playable.Play ();
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		Transform transform = other.transform;
		GameObject obj = transform.gameObject;
		if(obj){
			string tag = obj.tag;
			print ("Collide with: " + tag);
			if(canBeDamaged){
				if(tag.Equals("NPC_ENEMY")){
					addDamage(40);
					//				float xSpeed = JumpForce;
					//				float ySpeed = JumpForce;
					//				int xDirection = transform.position.x - this.transform.position.x > 0 ? -1:1;
					//				int yDirection = transform.position.y - this.transform.position.y > 0 ? -1:1;
					//				print ("xDirection: " + xDirection);
					//				print ("yDirection: " + yDirection);
					//				print ("transform.position.x - this.transform.position.x : " + (transform.position.x - this.transform.position.x) );
					//				print ("transform.position.y - this.transform.position.y: " + (transform.position.y - this.transform.position.y));
					//				MyRigidbody.AddForce(new Vector2(xSpeed * xDirection, ySpeed * yDirection));
					this.canMove = false;
					nextCanMove = 1.0f;
					//playerController.addScore (1);
					//Destroy(obj);
				} else if(tag.Equals("ENEMY_BULLET")){
					addDamage(10);
					Destroy(obj);
				}
			}
		}
		
	}
	void damageEnd(){
		MyAnimator.SetBool("isDamaged", false);
		//canBeDamaged = false;
		canMove = true;
	}
	IEnumerator Blink(float waitTime) {
		canBeDamaged = false;
		SpriteRenderer renderer = GetComponent<SpriteRenderer> ();
		float endTime = Time.time + waitTime;
		while( Time.time <= endTime){
			renderer.enabled = false;
			yield return new WaitForSeconds(0.2f);
			renderer.enabled = true;
			yield return new WaitForSeconds(0.2f);
		}
		canBeDamaged = true; //can be damaged at the end of the blinking
	}
	public bool getCanShoot(){
		return canShoot;
	}
	public void addDamage(int dmg){
		this.currentHP -= dmg;
		if (currentHP < 0) {
			currentHP = 0;
		} else {
			StartCoroutine(Blink(2.0F));
			MyAnimator.SetBool("isDamaged", true);
		}
	}
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
