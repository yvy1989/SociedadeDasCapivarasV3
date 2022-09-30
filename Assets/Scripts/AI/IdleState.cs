using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    private float idleCooldownCounter = 0f,
        idleCooldown = 2f,
        idlePatrolChance = 60f;

    public IdleState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Vector3 _initPos, AI _ai)
                        : base(_npc, _agent, _anim, _player, _initPos, _ai)
    {
        name = STATE.IDLE;
        agent.isStopped = true;
    }

    public override void Enter()
    {
        //Debug.Log("Idle");

        idleCooldownCounter = ai.idleCooldownCounter;
        idleCooldown = ai.idleCooldown;
        idlePatrolChance = ai.idlePatrolChance;

        idleCooldownCounter = 0f;
        anim.SetTrigger("isIdle");

        base.Enter();
    }

    public override void Update()
    {
        if (CanSeePlayer())
        {
            nextState = new PursueState(npc, agent, anim, player, initPos, ai);
            stage = EVENT.EXIT;
        }
        else if (idleCooldownCounter >= idleCooldown)
        {
            ////Debug.Log("test");
            if (Random.Range(0, 100) < idlePatrolChance)
            {
                ////Debug.Log("succeed");
                nextState = new PatrolState(npc, agent, anim, player, initPos, ai);
                stage = EVENT.EXIT;
            }
            idleCooldownCounter = 0;
        }
        else
        {
            idleCooldownCounter += Time.deltaTime;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }

    /*protected IEnumerator FlipCounterSwitchOnTimeCount(float time)
    {
        yield return new WaitForSeconds(time);
        this.counterSwitch = !this.counterSwitch;
        yield return null;
    }*/
}
