using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
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
        base.Enter();
    }

    public override void Update()
    {
        float range = 10;

        //if(Vector3.Distance(this))
        //agent.SetDestination(new Vector3(initPos.x + Random.Range(-range, range), initPos.y, initPos.z + Random.Range(-range, range)));

        base.Update();
    }

    public override void Exit()
    {
        anim.ResetTrigger("isWalking");
        base.Exit();
    }
}
