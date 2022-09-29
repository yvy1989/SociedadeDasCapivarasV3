using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State
{
    protected float visDist = 15f,
        visAngle = 100f,
        atkDist = 3f;

    public enum STATE
    {
        IDLE, PATROL, PURSUE, ATTACK
    };

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public STATE name;
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected NavMeshAgent agent;
    protected Vector3 initPos;
    protected AI ai;

    public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player, Vector3 _initPos, AI _ai)
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        stage = EVENT.ENTER;
        player = _player;
        initPos = _initPos;
        ai = _ai;
    }

    public virtual void Enter()
    {
        visDist = ai.visDist;
        visAngle = ai.visAngle;
        atkDist = ai.atkDist;

        stage = EVENT.UPDATE;
    }

    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    public bool CanSeePlayer()
    {
        Vector3 direction = player.transform.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        if(IsPlayerInVisualDistance() && angle <= visAngle / 2)
        {
            return true;
        }
        return false;
    }

    public bool IsPlayerInVisualDistance()
    {
        Vector3 direction = player.transform.position - npc.transform.position;
        if(direction.magnitude <= visDist)
        {
            return true;
        }
        return false;
    }

    public bool CanAttackPlayer()
    {
        Vector3 direction = player.transform.position - npc.transform.position;
        if(direction.magnitude <= atkDist)
        {
            return true;
        }
        return false;
    }
}
