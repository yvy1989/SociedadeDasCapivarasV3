using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public float _visDist = 15f, _visAngle = 100f, _atkDist = 3f, _idleCooldownCounter = 0f, _idleCooldown = 2f, _idlePatrolChance = 60f,
        _patrolSpeed = 2f, _patrolRange = 20f, _patrolTargetLeeway = 1f, _pursueSpeed = 5f, _attackRotationSpeed = 2f;
    
    public float visDist { get; private set; }
    public float visAngle { get; private set; }
    public float atkDist { get; private set; }
    public float idleCooldownCounter { get; private set; }
    public float idleCooldown { get; private set; }
    public float idlePatrolChance { get; private set; }
    public float patrolSpeed { get; private set; }
    public float patrolRange { get; private set; }
    public float patrolTargetLeeway { get; private set; }
    public float pursueSpeed { get; private set; }
    public float attackRotationSpeed { get; private set; }

    NavMeshAgent agent;
    Animator anim;
    Transform player;
    State currentState;
    Vector3 initPos;

    private void Awake()
    {
        visDist = _visDist;
        visAngle = _visAngle;
        atkDist = _atkDist;
        idleCooldownCounter = _idleCooldownCounter;
        idleCooldown = _idleCooldown;
        idlePatrolChance = _idlePatrolChance;
        patrolSpeed = _patrolSpeed;
        patrolRange = _patrolRange;
        patrolTargetLeeway = _patrolTargetLeeway;
        pursueSpeed = _pursueSpeed;
        attackRotationSpeed = _attackRotationSpeed;
    }

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
