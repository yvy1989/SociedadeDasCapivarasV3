using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    float rotationSpeed = 2f;

    public AttackState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Vector3 _initPos)
                        : base(_npc, _agent, _anim, _player, _initPos)
    {
        name = STATE.ATTACK;
        //agent.speed = 5f;
        agent.isStopped = true;
    }

    public override void Enter()
    {
        anim.SetTrigger("isAttacking");
        
        base.Enter();
    }

    public override void Update()
    {
        //base.Update();
        
    }

    public override void Exit()
    {
        anim.ResetTrigger("isAttacking");
        agent.isStopped = true;
        base.Exit();
    }
}
