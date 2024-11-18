using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private bool hasTakenDamage;

    public bool HasTakenDamage()
    {
        bool result = hasTakenDamage;
        hasTakenDamage = false; // Reinicia el estado de daño después de ser consultado
        return result;
    }

    public void TakeDamage()
    {
        hasTakenDamage = true;
    }
}
