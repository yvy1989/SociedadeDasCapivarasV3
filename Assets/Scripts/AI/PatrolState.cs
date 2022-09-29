using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    private float patrolSpeed = 2f,
        patrolRange = 20f,
        patrolTargetLeeway = 1f;

    public PatrolState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Vector3 _initPos, AI _ai)
                        : base(_npc, _agent, _anim, _player, _initPos, _ai)
    {
        name = STATE.PATROL;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        Debug.Log("Patrol");

        patrolRange = ai.patrolRange;
        patrolTargetLeeway = ai.patrolTargetLeeway;
        agent.speed = patrolSpeed;

        anim.SetTrigger("isWalking");
        agent.SetDestination(new Vector3(initPos.x + Random.Range(-patrolRange, patrolRange),
                                                                    initPos.y, initPos.z + Random.Range(-patrolRange, patrolRange)));
        base.Enter();
    }

    public override void Update()
    {
        //base.Update();
        if (agent.remainingDistance < patrolTargetLeeway)
        {
            nextState = new IdleState(npc, agent, anim, player, initPos, ai);
            stage = EVENT.EXIT;
        }

        if (CanSeePlayer())
        {
            nextState = new PursueState(npc, agent, anim, player, initPos, ai);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isWalking");
        agent.isStopped = true;
        base.Exit();
    }
}
