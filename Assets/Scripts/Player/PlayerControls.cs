using UnityEngine;
using System.Collections;


public class PlayerControls : MonoBehaviour {
	public float turnSmoothing = 15f;   // A smoothing value for turning the player.
	public float speedDampTime = 0.1f;  // The damping for the speed parameter
	
	
	private Animator anim;              // Reference to the animator component.

	CharacterController controller;

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public float jumpForward = 5.0F;
	private Vector3 moveDirection = Vector3.zero;
	
	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent<Animator>();
		
		// Set the weight of the shouting layer to 1.
		anim.SetLayerWeight(0, 0f);

		controller = GetComponent<CharacterController>();
	}
	
	
	void FixedUpdate ()
	{
		// Cache the inputs.
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		bool jump = Input.GetButton ("Jump");
		
		MovementManagement(h, v, jump);
	}
	
	
	void MovementManagement (float horizontal, float vertical, bool jump)
	{
		if (controller.isGrounded) {
			if (jump) {
				if (horizontal != 0f || vertical != 0f) {
					moveDirection = transform.forward * jumpForward;
				}
				moveDirection.y = jumpSpeed;
			} else {
				moveDirection.x = 0;
				moveDirection.z = 0;
			}
		}

		anim.SetBool ("isGrounded", controller.isGrounded);
		anim.SetBool ("Jump", jump);
		anim.SetFloat ("airVelocity", controller.velocity.y);

		// If there is some axis input...
		if((horizontal != 0f || vertical != 0f))
		{
			// ... set the players rotation and set the speed parameter to 5.0f.
			Rotating(horizontal, vertical);
			anim.SetFloat("Speed", 5.0f * Mathf.Max(Mathf.Abs(horizontal), Mathf.Abs(vertical)), speedDampTime, Time.deltaTime);
		}
		else
			// Otherwise set the speed parameter to 0.
			anim.SetFloat("Speed", 0);

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
	
	
	void Rotating (float horizontal, float vertical)
	{
		// Create a new vector of the horizontal and vertical inputs.
		Vector3 targetDirection = new Vector3(horizontal, 0f, vertical);
		
		// Create a rotation based on this new vector assuming that up is the global y axis.
		Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		
		// Create a rotation that is an increment closer to the target rotation from the player's rotation.
		Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		
		// Change the players rotation to this new rotation.
		rigidbody.MoveRotation(newRotation);
	}
}
