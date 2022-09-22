using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    float range = 20;

    public PatrolState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Vector3 _initPos)
                        : base(_npc, _agent, _anim, _player, _initPos)
    {
        name = STATE.PATROL;
        agent.speed = 2f;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        anim.SetTrigger("isWalking");
        agent.SetDestination(new Vector3(initPos.x + Random.Range(-range, range), initPos.y, initPos.z + Random.Range(-range, range)));
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (agent.remainingDistance < 1)
        {
            nextState = new IdleState(npc, agent, anim, player, initPos);
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
