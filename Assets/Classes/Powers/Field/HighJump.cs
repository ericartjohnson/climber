using UnityEngine;
using System;
using System.Collections;

public class HighJump : Power {

	private Action<object> userJumpedAction;

	// Use this for initialization
	void Start () {
		title = "High Jump";
		perform();
		userJumpedAction = o => onUserJumped(o);
		BroadcastCenter.addListener(userJumpedAction,"userJumped");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void perform () {
		base.perform();
		Debug.Log("Perform power: " + title);
	}

	private void onUserJumped(object data){
		Debug.Log("User jumped callback with data: " + data.ToString());
		BroadcastCenter.removeListener(userJumpedAction,"userJumped");
	}
}