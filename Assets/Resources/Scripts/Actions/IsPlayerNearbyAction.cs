using UnityEngine;

[CreateAssetMenu(fileName = "IsPlayerNearbyAction", menuName = "ScriptableObjects/Actions/IsPlayerNearby")]
public class IsPlayerNearbyAction : Action
{
    public float detectionRadius = 10f; // Radio de detección para activar la persecución

    public override bool Check(GameObject owner)
    {
       
        TargetReference targetReference = owner.GetComponent<TargetReference>();

        if (targetReference != null && targetReference.target != null)
        {
            float distance = Vector3.Distance(owner.transform.position, targetReference.target.transform.position);
            return distance <= detectionRadius;
        }

        return false;
    }

    public override void DrawGizmos(GameObject owner)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(owner.transform.position, detectionRadius);
    }
}
