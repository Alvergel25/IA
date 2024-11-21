using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "FleeState (S)", menuName = "ScriptableObjects/States/FleeStates")]
public class FleeState : State
{
    public override State Run(GameObject owner)
    {
            // . . Esto deberia tener el mismo nombre en todos
        State state = CheckActions(owner);
        TargetReference reference = owner.GetComponent<TargetReference>();
        NavMeshAgent nAgent = owner.GetComponent<NavMeshAgent>();

        Vector3 flee = (owner.transform.position - reference.target.transform.position).normalized; //Enemy-Player
        nAgent.SetDestination(owner.transform.position + (flee * 10));
        return state;
    }
    protected override void PerformAction(GameObject owner)
    {
        throw new System.NotImplementedException();
    }
}
