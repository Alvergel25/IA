using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState (S)", menuName = "ScriptableObjects/States/ChaseState")]
public class ChaseState : State
{
    public string blendParameter; // Nombre del par�metro de animaci�n para el blend de velocidad

    // M�todo que ejecuta la l�gica espec�fica del estado de persecuci�n
    protected override void PerformAction(StateMachine owner)
    {
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        Animator animator = owner.GetComponent<Animator>();
        TargetReference targetReference = owner.GetComponent<TargetReference>();

        // Verifica que el TargetReference tenga un objetivo asignado
        if (targetReference != null && targetReference.target != null)
        {
            GameObject target = targetReference.target;

            // Establece el destino del agente hacia la posici�n del objetivo
            navMeshAgent.SetDestination(target.transform.position);

            // Ajusta el par�metro del blend de animaci�n seg�n la velocidad del agente
            animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed);
        }
    }
}
