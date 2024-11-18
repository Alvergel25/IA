//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//[CreateAssetMenu(fileName = "GuardState (S)", menuName = "ScriptableObjects/States/GuardStates")]
//public class GuardState : State
//{
//    public Vector3 guardPoint;

//    public string blendParameter;

//    public override State Run(GameObject owner)
//    {
//        State nextState = CheckActions(owner);

//        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
//        Animator animator = owner.GetComponent<Animator>();

//        navMeshAgent.SetDestination(guardPoint);
//        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed);

//        return nextState;
//    }
//}
