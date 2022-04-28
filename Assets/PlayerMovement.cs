using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	public float runSpeed = 40f;
	float horizontalMove = 0f;
 bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}
if(jump == false) {
	 animator.SetBool("IsJumping", false);

}
		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
			animator.SetBool("Crouch", true);
			runSpeed = 0f;
		} else if (Input.GetButtonUp("Crouch"))
{
	crouch = false;
				animator.SetBool("Crouch", false);
			runSpeed = 40f;
}

	}
	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
