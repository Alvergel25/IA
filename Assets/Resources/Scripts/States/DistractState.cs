using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "DistractState (S)", menuName = "ScriptableObjects/States/DistractState")]
public class DistractState : State
{
    public float distractionDuration = 3f; // Duraci�n de la distracci�n en segundos
    private float distractionStartTime;

    protected override void PerformAction(StateMachine owner)
    {
        Animator animator = owner.GetComponent<Animator>();
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();

        // Detiene el movimiento del agente mientras est� distra�do
        navMeshAgent.isStopped = true;

        // Inicia la animaci�n de distracci�n
        animator.SetBool("IsDistracted", true);

        // Si ha pasado la duraci�n de la distracci�n, vuelve a habilitar el movimiento
        if (Time.time - distractionStartTime > distractionDuration)
        {
            navMeshAgent.isStopped = false;
            animator.SetBool("IsDistracted", false);
        }
    }

    public override State Run(StateMachine owner)
    {
        // Reinicia el tiempo de distracci�n cuando entra en este estado
        distractionStartTime = Time.time;
        return base.Run(owner);
    }
}
