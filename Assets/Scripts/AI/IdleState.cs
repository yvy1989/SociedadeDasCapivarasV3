using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    float counterFloat = 0;

    public IdleState(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Vector3 _initPos)
                        : base(_npc, _agent, _anim, _player, _initPos)
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
        //base.Update();
        if (counterFloat >= 2)
        {
            Debug.Log("test");
            if (Random.Range(0, 100) < 60)
            {
                Debug.Log("succeed");
                nextState = new PatrolState(npc, agent, anim, player, initPos);
                stage = EVENT.EXIT;
            }
            counterFloat = 0;
        }
        else
        {
            counterFloat += Time.deltaTime;
        }

        if (CanSeePlayer())
        {
            nextState = new PursueState(npc, agent, anim, player, initPos);
            stage = EVENT.EXIT;
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
