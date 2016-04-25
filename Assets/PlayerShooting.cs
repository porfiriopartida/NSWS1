using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	[SerializeField] private LayerMask shootableMask;
	
	private int damagePerShot = 20;                  // The damage inflicted by each bullet.
	private float timeBetweenBullets = 0.15f;        // The time between each shot.
	float timer;                                    // A timer to determine when to fire.
	AudioSource gunAudio;                           // Reference to the audio source.
	public float bulletForce = 200f;
	[SerializeField] public GameObject bulletBill;
	MegamanController playerController;
	void Start(){
		//playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MegamanController>();
		playerController = this.transform.parent.gameObject.GetComponent<MegamanController>();
	}

	void Awake ()
	{
		// Create a layer mask for the Shootable layer.
		loadPrefabs();
		
		// Set up the references.
		gunAudio = GetComponent<AudioSource> ();
	}
	void loadPrefabs(){
		//bulletBill = (GameObject)Instantiate (Resources.Load ("Bullet"));
	}

	
	void Update ()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
		//print ("Timer " + timer);
		//print ("timeBetweenBullets " + timeBetweenBullets);
		
		// If the Fire1 button is being press and it's time to fire...
		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets)
		{
			// ... shoot the gun.
			Shoot ();
		}
	}
	GameObject getBullet(){
		//GameObject clonedBullet = Instantiate ((GameObject)Instantiate (Resources.Load ("Bullet")), transform.position, transform.rotation) as GameObject;
		GameObject clonedBullet = Instantiate (bulletBill, transform.position, transform.rotation) as GameObject;
		return clonedBullet;
	}

	void Shoot ()
	{
		print ("Shooting");
		// Reset the timer.
		timer = 0f;
		// Play the gun shot audioclip.
		gunAudio.Play ();

		GameObject clonedBullet = getBullet ();
		Rigidbody2D body = clonedBullet.GetComponent<Rigidbody2D>();
		Vector3 bulletScale = clonedBullet.transform.localScale;
		int side = playerController.isFacingRight() ? -1 : 1;
		//print ("Facing right: " + playerController.isFacingRight().ToString());
		//print ("Side: " + side);
		clonedBullet.transform.localScale = new Vector3 ( bulletScale.x * (side), bulletScale.y, 1);
		//transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
		body.AddForce (new Vector2(bulletForce * -side, 0));
	}
}
