using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    private float attackRotationSpeed = 2f;
    bool CanaudioAtk = true;
    float timeAudioAtk;

    public AttackState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Vector3 _initPos, AI _ai)
                        : base(_npc, _agent, _anim, _player, _initPos, _ai)
    {
        name = STATE.ATTACK;
        agent.isStopped = true;
    }
    
    public override void Enter()
    {
        //Debug.Log("Attack");
        if(CanaudioAtk){
            SoudManager.PlaySound(SoudManager.SoudType.JaguarAttack);
            CanaudioAtk=false;
        }else{
            if(timeAudioAtk>60){
                CanaudioAtk=true;
            }

        }
       
        attackRotationSpeed = ai.attackRotationSpeed;

        anim.SetTrigger("isAttacking");

        base.Enter();
    }

    public override void Update()
    {
        if(CanaudioAtk==false){
            timeAudioAtk+=Time.deltaTime;
        }else{
            timeAudioAtk=0;
        }
        Vector3 direction = player.transform.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        direction.y = 0;

        npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * attackRotationSpeed);

        if (!CanAttackPlayer())
        {
            nextState = new PursueState(npc, agent, anim, player, initPos, ai);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isAttacking");
        agent.isStopped = true;
        base.Exit();
    }
}
