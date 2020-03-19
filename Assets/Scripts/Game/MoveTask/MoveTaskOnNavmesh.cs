using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveTaskOnNavmesh : MoveTaskBase
{
    private NavMeshAgent agent;


    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void StartMoving(GameObject target)
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
    }
    protected override void StopMoving()
    {
        agent.isStopped = true;
    }
}
