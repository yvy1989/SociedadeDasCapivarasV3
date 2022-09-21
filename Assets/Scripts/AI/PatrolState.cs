using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    public PatrolState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player)
                        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.PATROL;
        agent.speed = 2f;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        anim.SetTrigger("isWalking");
        base.Enter();
    }

    public override void Update()
    {
        //implementar codigo de patrulha

        base.Update();
    }

    public override void Exit()
    {
        anim.ResetTrigger("isWalking");
        base.Exit();
    }
}
