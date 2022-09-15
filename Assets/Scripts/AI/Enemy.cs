using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _navMeshAgent.isStopped = false;
    }

    private void LateUpdate()
    {
        float _distance = Vector3.Distance(transform.position, player.transform.position);
        if (_distance > 2f && _distance < 10f)
            _navMeshAgent.isStopped = false;
        else
            _navMeshAgent.isStopped = true;

        if (!_navMeshAgent.isStopped)
            _navMeshAgent.destination = player.transform.position;                
    }
}
