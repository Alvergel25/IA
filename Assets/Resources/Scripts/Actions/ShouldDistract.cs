using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/ShouldDistract")]
public class ShouldDistract : Action
{
    [Range(0f, 1f)]
    public float distractionChance = 0.3f; // Probabilidad de distracción (30% por defecto)

    public override bool Check(GameObject owner)
    {
        // Retorna true si el número aleatorio está dentro del rango de distracción
        return Random.value < distractionChance;
    }

    public override void DrawGizmos(GameObject owner)
    {
        // Este método no necesita dibujar Gizmos en este caso
    }
}
