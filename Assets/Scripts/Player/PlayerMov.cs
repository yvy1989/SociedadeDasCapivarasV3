using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Transform axis;
   




    private void Start()
    {
       
    }

    public void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 rotateTargetZ = axis.transform.forward;
        rotateTargetZ.y = 0;
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.LookRotation(rotateTargetZ);
            var dir = transform.forward * speed* Time.deltaTime;
            rb.velocity = dir;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.LookRotation(rotateTargetZ);
            var dir = transform.forward*-1* speed * Time.deltaTime;
            rb.velocity = dir;
        }
        Vector3 rotateTargetX = axis.transform.right;
        rotateTargetX.y = 0;
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.LookRotation(rotateTargetX);
            var dir = transform.forward * speed * Time.deltaTime;
            rb.velocity = dir;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.LookRotation(rotateTargetX*-1);
            var dir = transform.forward * speed * Time.deltaTime;
            rb.velocity = dir;
        }


    }
}



