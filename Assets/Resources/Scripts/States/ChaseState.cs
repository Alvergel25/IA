using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState (S)", menuName = "ScriptableObjects/States/ChaseState")]
public class ChaseState : State
{
    public string blendParameter; // Nombre del parámetro de animación para el blend de velocidad

    // Método que ejecuta la lógica específica del estado de persecución
    protected override void PerformAction(StateMachine owner)
    {
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        Animator animator = owner.GetComponent<Animator>();
        TargetReference targetReference = owner.GetComponent<TargetReference>();

        // Verifica que el TargetReference tenga un objetivo asignado
        if (targetReference != null && targetReference.target != null)
        {
            GameObject target = targetReference.target;

            // Establece el destino del agente hacia la posición del objetivo
            navMeshAgent.SetDestination(target.transform.position);

            // Ajusta el parámetro del blend de animación según la velocidad del agente
            animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed);
        }
    }
}
