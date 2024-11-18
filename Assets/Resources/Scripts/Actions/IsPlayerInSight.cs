using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/IsPlayerInSight")]
public class IsPlayerInSight : Action
{
    public float sightRange = 10f; // Rango de visión del enemigo

    public override bool Check(GameObject owner)
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return false;

        float distance = Vector3.Distance(owner.transform.position, player.transform.position);
        return distance <= sightRange;
    }

    // Dibuja una esfera de Gizmo para visualizar el rango de visión
    public override void DrawGizmos(GameObject owner)
    {
        Gizmos.color = Color.yellow; // Elige el color de la esfera
        Gizmos.DrawWireSphere(owner.transform.position, sightRange); // Dibuja la esfera en el rango especificado
    }
}
