using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    public IdleState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
                        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (Random.Range(0,100) < 10)
        {
            nextState = new PatrolState(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }      
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}
