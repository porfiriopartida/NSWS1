using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	private Transform target;		//target for the camera to follow
	public float xOffset;			//how much x-axis space should be between the camera and target
	public bool followY;			//how much x-axis space should be between the camera and target

	void Start(){
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{
		//follow the target on the x-axis only
		transform.position = new Vector3 (target.position.x + xOffset, followY ? target.position.y:transform.position.y, transform.position.z);
	}
}
