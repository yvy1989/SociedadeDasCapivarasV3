using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Transform axis;

    public bool canWalk = true;

    Animator anim;


    private void OnEnable()
    {
        Collectable.ItemCollected += startCollectAnim;// inscricao no evento chamado por Collectable
    }

    private void OnDisable()
    {
        Collectable.ItemCollected -= startCollectAnim;
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        if (canWalk)
        {
            Move();
        }
        
        
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


        anim.SetFloat("speed", rb.velocity.magnitude);

    }

    void startCollectAnim()
    {
        StartCoroutine(delayAnim("pick",1.15f));// delay para iniciar e parar animacao de pegar item
    }

    IEnumerator delayAnim(string animName,float time)
    {
        canWalk = false;
        anim.SetBool(animName, true);
        
        yield return new WaitForSeconds(time);
        anim.SetBool(animName, false);
        canWalk = true;
    }
}



