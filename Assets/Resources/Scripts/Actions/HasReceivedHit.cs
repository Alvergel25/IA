using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/HasReceivedHit")]
public class HasReceivedHit : Action
{
    public override bool Check(GameObject owner)
    {
        EnemyHealth enemyHealth = owner.GetComponent<EnemyHealth>();
        return enemyHealth != null && enemyHealth.HasTakenDamage();
    }

    public override void DrawGizmos(GameObject owner)
    {
        // No se necesita un Gizmo especial para esta acción
    }
}
