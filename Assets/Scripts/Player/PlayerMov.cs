using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10;
    public float rotationSpeed;
    public float jumpSpeed = 10f;
    public float gravity = 20.0f;

    public GameObject circleCollider;

    private Vector3 rotation;

    private Vector3 move = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    public void Update()
    {
        if (controller.isGrounded)
        {
            

            move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
            move = this.transform.TransformDirection(move);


            

            controller.Move(move * speed);
            

            /*
            if (Input.GetButton("Jump"))
            {
                move.y = jumpSpeed;
            }*/
        }

        move.y -= gravity * Time.deltaTime;

        // Move the controller
        controller.Move(move * Time.deltaTime);

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotationSpeed*Time.deltaTime);

    }
}



