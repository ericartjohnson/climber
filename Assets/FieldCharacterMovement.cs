using UnityEngine;
using System.Collections;
using JsonFx.Json;

[RequireComponent (typeof(CharacterController))]

public class FieldCharacterMovement : MonoBehaviour {

	public float speed = 6.0f;
	public float crouchSpeed = 3.0f;
	public float jumpSpeed = 8.0f;
	public float jumpBoost = 4.0f;
	public float gravity = 20.0f;
	public float inAirModifier = 3.0f;
	public bool highJumpReady = false;
	public float highJumpTimeout = 3.0f;

	private float highJumpCurTimeout;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		highJumpCurTimeout = highJumpTimeout;
	}//Start
	
	// Update is called once per frame
	void Update(){
		UpdateMovement();
	}
	
	void UpdateMovement (){
		CharacterController controller = GetComponent<CharacterController>();
	    if (controller.isGrounded) {
	        // We are grounded, so recalculate
	        // move direction directly from axes
	        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
	        moveDirection = transform.TransformDirection(moveDirection);

	        float s = speed;

	        if(Input.GetButton("Crouch")){
	        	s = crouchSpeed;
	        	highJumpCurTimeout -= Time.deltaTime;
	        	if(highJumpCurTimeout <= 0){
	        		highJumpReady = true;
	        		highJumpCurTimeout = highJumpTimeout;
	        	}
	        }else{
	        	highJumpReady = false;
	        	highJumpCurTimeout = highJumpTimeout;
	        }
	  
	        moveDirection *= s;

	        if (Input.GetButton ("Jump")) {
	            moveDirection.y = jumpSpeed;
	            if(highJumpReady) moveDirection.y += jumpBoost;
	            highJumpReady = false;
	            highJumpCurTimeout = highJumpTimeout;

	            BroadcastCenter.broadcastMessage("userJumped", "test data");
	        }
	    }else{
	    	moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, 0);
	        moveDirection = transform.TransformDirection(moveDirection);
	        moveDirection = new Vector3(moveDirection.x * speed, moveDirection.y,0);
	        moveDirection.y -= gravity * Time.deltaTime;
	    }

	    // Apply gravity
	    //moveDirection.y -= gravity * Time.deltaTime;
	    
	    // Move the controller
	    controller.Move(moveDirection * Time.deltaTime);
	}//UpdateMovement

}//FieldCharacterMovement