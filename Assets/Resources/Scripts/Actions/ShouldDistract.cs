using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/ShouldDistract")]
public class ShouldDistract : Action
{
    [Range(0f, 1f)]
    public float distractionChance = 0.3f; // Probabilidad de distracci�n (30% por defecto)

    public override bool Check(GameObject owner)
    {
        // Retorna true si el n�mero aleatorio est� dentro del rango de distracci�n
        return Random.value < distractionChance;
    }

    public override void DrawGizmos(GameObject owner)
    {
        // Este m�todo no necesita dibujar Gizmos en este caso
    }
}
