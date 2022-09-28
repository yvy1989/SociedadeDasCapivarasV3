using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    private float patrolRange = 20,
        patrolTargetLeeway = 1;

    public PatrolState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Vector3 _initPos, AI _ai)
                        : base(_npc, _agent, _anim, _player, _initPos, _ai)
    {
        name = STATE.PATROL;
        agent.speed = 2f;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        Debug.Log("Patrolling");
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
