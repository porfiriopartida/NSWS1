using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	[SerializeField] private LayerMask enemiesMask;
	[SerializeField] private float timeLeft = 3;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if ( timeLeft < 0 )
		{
			Destroy(this.gameObject);
		}
	}
}
