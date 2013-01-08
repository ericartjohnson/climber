using UnityEngine;
using System;
using System.Collections;

public class Power : MonoBehaviour {

	public bool fieldEnabled = false;
	public bool battleEnabled = false;
	public string title = "Unknown Power";


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void perform () {
		//override this
		Debug.Log("(base) Perform power: " + title);
	}
}
