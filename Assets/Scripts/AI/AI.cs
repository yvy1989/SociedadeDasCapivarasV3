using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public float visDist { get; private set; }
    public float visAngle { get; private set; }
    public float atkDist { get; private set; }
    public float idleCooldownCounter { get; private set; }
    public float idleCooldown { get; private set; }
    public float idlePatrolChance { get; private set; }
    public float patrolRange { get; private set; }
    public float patrolTargetLeeway { get; private set; }
    public float pursueSpeed { get; private set; }
    public float attackRotationSpeed { get; private set; }

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
        currentState = new IdleState(gameObject, agent, anim, player, initPos, this);
    }

    void Update()
    {
        currentState = currentState.Process();
    }
}
