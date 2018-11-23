using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHandler))]
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    public float walkSpeed = 150;
    public float runSpeed;
    public float jumpHeight;
    public float gravity = 9.81f;
    [Header ("Components")]
    public PlayerHandler handler;
    public CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;//direction the player is moving

    void Start()
    {
        //Gets the components
        handler = GetComponent<PlayerHandler>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float speed = walkSpeed;//speed that we're moving at

        //Running
        if (Input.GetKey(GameManager.run))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        //Moving backwards and forwards
        if (Input.GetKey(GameManager.forward))
        {
            moveDirection.z = speed;
        }
        else if (Input.GetKey(GameManager.backward))
        {
            moveDirection.z = -speed;
        }
        else
        {
            moveDirection.z = 0;
        }

        //Moving left and right
        if (Input.GetKey(GameManager.left))
        {
            moveDirection.x = -speed;
        }
        else if (Input.GetKey(GameManager.right))
        {
            moveDirection.x = speed;
        }
        else
        {
            moveDirection.x = 0;
        }
        //Jumping and gravity
        if (controller.isGrounded && Input.GetKey(GameManager.jump))
        {
            moveDirection.y = jumpHeight;
        }
        else
        {
            moveDirection.y -= gravity;//Gives gravity
        }

        moveDirection = transform.TransformDirection(moveDirection);//Makes the player go in the direction it's facing

        controller.Move(moveDirection * Time.deltaTime);//Makes the player move
    }
}
