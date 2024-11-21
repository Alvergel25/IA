using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "PatrolState (S)", menuName = "ScriptableObjects/States/PatrolState")]
public class PatrolState : State
{
    public Vector3[] patrolPoints; // Array de puntos de patrullaje
    private int currentPatrolIndex;

    protected override void PerformAction(GameObject owner)
    {

        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        Animator animator = owner.GetComponent<Animator>();

        if (patrolPoints.Length == 0) return;

        // Si el agente ha llegado al punto de patrullaje actual, cambia al siguiente
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            navMeshAgent.SetDestination(patrolPoints[currentPatrolIndex]);
        }

        // Control de animaci�n
        animator.SetFloat("Speed", navMeshAgent.velocity.magnitude / navMeshAgent.speed);
    }
}
