using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	[SerializeField] private LayerMask enemiesMask;
	[SerializeField] private float timeLeft = 3;
	[SerializeField] private LayerMask destroyable;
	// Use this for initialization
	MegamanController playerController;
	void Start () {
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MegamanController>();
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			Destroy(this.gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject obj = other.transform.gameObject;
		if(obj){
			string tag = obj.tag;
			if(tag.Equals("NPC_ENEMY")){
				playerController.addScore (1);
				Destroy(obj);
				Destroy (this.gameObject);
			}
		}

	}
}
