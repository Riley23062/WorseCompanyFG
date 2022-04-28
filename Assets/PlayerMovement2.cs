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

		if (Input.GetButtonDown("Jump"))
		{
			jump2 = true;
		}

	}

	void FixedUpdate()
	{
		// Move our character
		controller2.Move(horizontalMove2 * Time.fixedDeltaTime, crouch2, jump2);
		jump2 = false;
	}
}

