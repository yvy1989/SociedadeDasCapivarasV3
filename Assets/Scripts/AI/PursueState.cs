using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PursueState : State
{
    private float pursueSpeed = 5f;

    public PursueState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Vector3 _initPos, AI _ai)
                        : base(_npc, _agent, _anim, _player, _initPos, _ai)
    {
        name = STATE.PURSUE;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        //Debug.Log("Pursue");

        pursueSpeed = ai.pursueSpeed;
        agent.speed = pursueSpeed;

        agent.isStopped = false;
        anim.SetTrigger("isRunning");

        base.Enter();
    }

    public override void Update()
    {
        agent.SetDestination(player.transform.position);
        if (CanAttackPlayer())
        {
            nextState = new AttackState(npc, agent, anim, player, initPos, ai);
            stage = EVENT.EXIT;
        }
        else if (agent.hasPath)
        { 
            if (!IsPlayerInVisualDistance())
            {
                nextState = new IdleState(npc, agent, anim, player, initPos, ai);
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
