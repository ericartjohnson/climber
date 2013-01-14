using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform targetTransform;

	// Use this for initialization
	void Start () {

	}
	
	// LateUpdate is called once per frame after all other Update calls
	void LateUpdate () {
		transform.position = new Vector3(targetTransform.position.x,targetTransform.position.y,transform.position.z);
	}
}
