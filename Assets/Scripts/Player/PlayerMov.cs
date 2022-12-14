using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 100f;


    public Transform axis;
    Vector3 dir = Vector3.zero;

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
        characterController = GetComponent<CharacterController>();
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
        dir = Vector3.zero;
        //Vector3 dir = Vector3.zero;
        Vector3 rotateTargetZ = axis.transform.forward;
        rotateTargetZ.y = 0;

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation =Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotateTargetZ),Time.deltaTime*5);
            dir = transform.forward;
            characterController.SimpleMove(dir * Time.deltaTime * speed);
             SoudManager.PlaySound(SoudManager.SoudType.PlayerMove);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation =Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotateTargetZ),Time.deltaTime*5);
            dir = transform.forward * -1 ;
            characterController.SimpleMove(dir * Time.deltaTime * speed);
             SoudManager.PlaySound(SoudManager.SoudType.PlayerMove);
        }

        if (Input.GetMouseButton(0) && GetComponent<Player>().isHoldItem == true)
        {
            //anim.SetBool("atack",true);
            Atack();
        }

        Vector3 rotateTargetX = axis.transform.right;
        rotateTargetX.y = 0;
        
        if (Input.GetKey(KeyCode.D))
        {
             transform.rotation =Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotateTargetX),Time.deltaTime*5);
            dir = transform.forward;
            characterController.SimpleMove(dir * Time.deltaTime * speed);
             SoudManager.PlaySound(SoudManager.SoudType.PlayerMove);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation =Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotateTargetX*-1),Time.deltaTime*5);
            dir = transform.forward;
            characterController.SimpleMove(dir * Time.deltaTime * speed);
            SoudManager.PlaySound(SoudManager.SoudType.PlayerMove);
        }


        anim.SetFloat("speed", dir.magnitude);

    }

    private void Atack()
    {

        StartCoroutine(delayAnim("atack", 1.15f));
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f))
        {
            Debug.Log("Did Hit "+ hit.transform.name);
            hit.transform.GetComponent<Animator>().SetBool("cut", true);
            hit.transform.GetComponent<SpawnItems>().SpanwItem();
        }
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



