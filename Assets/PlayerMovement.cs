using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
    public int coinValue = 1;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	
	public Animator animator;

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			animator.SetBool("isJumping", true);
			jump = true;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("coin"))
		{
			Destroy(other.gameObject);
            ScoreManager.instance.ChangeScore(coinValue);

		}
	}

	public void OnLanding()
	{
		animator.SetBool("isJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
