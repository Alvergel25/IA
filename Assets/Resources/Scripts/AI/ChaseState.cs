using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState (S)", menuName = "ScriptableObjects/States/ChaseState")]
public class ChaseState : State
{
    public string blendParameter;

    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        Animator animator = owner.GetComponent<Animator>();
        GameObject target = owner.GetComponent<TargetReference>().target;

        navMeshAgent.SetDestination(target.transform.position);
        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed);

        return nextState;
    }
}