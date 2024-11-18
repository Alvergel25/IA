using UnityEngine;

[CreateAssetMenu(fileName = "AttackState (S)", menuName = "ScriptableObjects/States/AttackState")]
public class AttackState : State
{
    public float attackCooldown = 2f; // Tiempo entre ataques
    private float lastAttackTime;

    protected override void PerformAction(StateMachine owner)
    {
        Animator animator = owner.GetComponent<Animator>();
        TargetReference targetReference = owner.GetComponent<TargetReference>();

        if (targetReference != null && targetReference.target != null)
        {
            // Verifica si ha pasado el tiempo de enfriamiento del ataque
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                // Ejecuta la animación de ataque
                animator.SetTrigger("Attack");
                lastAttackTime = Time.time;
                Debug.Log("Atacando al jugador");
            }
        }
    }
}
