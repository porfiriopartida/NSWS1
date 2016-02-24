using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	[SerializeField] private LayerMask shootableMask;
	
	private int damagePerShot = 20;                  // The damage inflicted by each bullet.
	private float timeBetweenBullets = 0.15f;        // The time between each shot.
	float timer;                                    // A timer to determine when to fire.
	AudioSource gunAudio;                           // Reference to the audio source.
	public float bulletForce = 20f;
	void Awake ()
	{
		// Create a layer mask for the Shootable layer.
		loadPrefabs();
		
		// Set up the references.
		gunAudio = GetComponent<AudioSource> ();
	}
	void loadPrefabs(){
	}
	
	void Update ()
	{
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
		print ("Timer " + timer);
		print ("timeBetweenBullets " + timeBetweenBullets);
		
		// If the Fire1 button is being press and it's time to fire...
		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets)
		{
			// ... shoot the gun.
			Shoot ();
		}
	}
	GameObject getBullet(){
		GameObject clonedBullet = Instantiate ((GameObject)Instantiate (Resources.Load ("Bullet")), transform.position, transform.rotation) as GameObject;
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
		body.AddForce (new Vector2(bulletForce, 0));
	}
}
