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
    public GameObject cam;

    public Vector3 move = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    public void Update()
    {
        if (controller.isGrounded)
        {
            

            move = new Vector3(Input.GetAxisRaw("Horizontal")*Time.deltaTime, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
            move = this.transform.TransformDirection(move);
           
       
        


            

            controller.Move(move * speed);
            if (move.x != 0 || move.z != 0)
            {
                controller.Move(move * speed);
                transform.rotation = new Quaternion(transform.rotation.x,cam.transform.rotation.y,transform.rotation.z,transform.rotation.w);

            }
            // ativar essa linha de baixo para sair o som
            // SoudManager.PlaySound(SoudManager.SoudType.PlayerMove);



            /*
            if (Input.GetButton("Jump"))
            {
                move.y = jumpSpeed;
            }*/
        }
            
        move.y -= gravity * Time.deltaTime;
        controller.Move(move * Time.deltaTime);

    }
}



