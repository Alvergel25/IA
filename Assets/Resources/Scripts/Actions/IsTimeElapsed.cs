using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/IsTimeElapsed")]
public class IsTimeElapsed : Action
{
    public float duration = 5f; // Duraci�n en segundos
    private float startTime;

    public override bool Check(GameObject owner)
    {
        if (startTime == 0f)
        {
            startTime = Time.time;
        }

        bool isElapsed = (Time.time - startTime) >= duration;

        if (isElapsed)
        {
            startTime = 0f; // Reinicia el tiempo si ha pasado la duraci�n
        }

        return isElapsed;
    }

    public override void DrawGizmos(GameObject owner)
    {
        // No se necesita un Gizmo especial para esta acci�n
    }
}
