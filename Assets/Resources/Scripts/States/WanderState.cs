using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "WanderState (S)", menuName = "ScriptableObjects/States/WanderStates")]
public class WanderState : State
{
    public float maxTime;
    public float radius;

    private float currentTime;
    public override State Run(GameObject owner)
    {
        State nextState = CheckActions(owner);

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        currentTime += Time.deltaTime;

        if(currentTime >= maxTime)
        {
            bool pointFound = false;
            do
            {
                Vector3 randomPoint = owner.transform.position + Random.insideUnitSphere * radius;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, radius, NavMesh.AllAreas))
                {
                    navMeshAgent.SetDestination(hit.position);
                    pointFound = true;
                }
            } while (!pointFound);

            currentTime = 0;

        }

        return nextState;
    }

    //Esto es mio no de diego y no es lo mejor del mundo
    protected override void PerformAction(GameObject owner)
    {
        throw new System.NotImplementedException();
    }
}
