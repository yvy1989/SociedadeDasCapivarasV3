using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PursueState : State
{
    public PursueState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Vector3 _initPos)
                        : base(_npc, _agent, _anim, _player, _initPos)
    {
        name = STATE.PURSUE;
        agent.speed = 5f;
    }

    public override void Enter()
    {
        agent.isStopped = false;
        Debug.Log("Pursuing");
        anim.SetTrigger("isRunning");
        base.Enter();
    }

    public override void Update()
    {
        agent.SetDestination(player.transform.position);
        if (CanAttackPlayer())
        {
            nextState = new AttackState(npc, agent, anim, player, initPos);
            stage = EVENT.EXIT;
        }
        else if (agent.hasPath)
        { 
            if (!IsPlayerInVisualDistance())
            {
                nextState = new IdleState(npc, agent, anim, player, initPos);
                stage = EVENT.EXIT;
            }
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isRunning");
        agent.isStopped = true;
        base.Exit();
    }
}
