using UnityEngine;

[CreateAssetMenu(fileName = "TurnToPlayerState (S)", menuName = "ScriptableObjects/States/TurnToPlayerState")]
public class TurnToPlayerState : State
{
    public float turnSpeed = 3f; // Velocidad de giro hacia el jugador

    protected override void PerformAction(GameObject owner)
    {
        TargetReference targetReference = owner.GetComponent<TargetReference>();

        if (targetReference != null && targetReference.target != null)
        {
            Vector3 direction = (targetReference.target.transform.position - owner.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
        }
    }
}
