using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 150;
    public float runSpeed;
    public float jumpHeight;
    public float gravity = 9.81f;
    public PlayerHandler handler;
    public CharacterController controller;

	void Start ()
    {
        handler = GetComponent<PlayerHandler>();
        controller = GetComponent<CharacterController>();
        test = GameManager.forward;
	}
	
	void Update ()
    {
        if (!controller.isGrounded)
        {
            controller.SimpleMove(Vector3.down * (gravity * Time.deltaTime));
        }
        if (Input.GetKey(GameManager.forward))
        {
            controller.SimpleMove(Vector3.forward * (walkSpeed * Time.deltaTime));
        }
	}
}
