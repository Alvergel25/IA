using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/IsPlayerWithinAttackRange")]
public class IsPlayerWithinAttackRange : Action
{
    public float attackRange = 2f; // Rango de ataque del enemigo

    public override bool Check(GameObject owner)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return false;

        float distance = Vector3.Distance(owner.transform.position, player.transform.position);
        return distance <= attackRange;
    }

    public override void DrawGizmos(GameObject owner)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(owner.transform.position, attackRange);
    }
}
