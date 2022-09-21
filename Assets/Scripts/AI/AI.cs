using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    Transform player;
    State currentState;
    Vector3 initPos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initPos = transform.position;
        currentState = new IdleState(gameObject, agent, anim, player, initPos);
    }

    void Update()
    {
        currentState = currentState.Process();
    }
}
