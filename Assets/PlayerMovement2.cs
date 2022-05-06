using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

	public CharacterController2D controller2;
	public Animator animator;
	public float runSpeed = 40f;

	float horizontalMove2 = 0f;
	bool jump2 = false;
	bool crouch2 = false;
	// Update is called once per frame
	void Update()
	{

		horizontalMove2 = Input.GetAxisRaw("Horizontal2") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove2));

		if (Input.GetButtonDown("Jump2"))
		{
			jump2 = true;
		}

		if (Input.GetButtonDown("Crouch2"))
		{
			crouch2 = true;
			runSpeed = 0f;
			} else if (Input.GetButtonUp("Crouch2"))
			{
				crouch2 = false;
				runSpeed = 40f;
			}

	}
	void FixedUpdate()
	{
		// Move our character
		controller2.Move(horizontalMove2 * Time.fixedDeltaTime, crouch2, jump2);
		jump2 = false;
	}
}
