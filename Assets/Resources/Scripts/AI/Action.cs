using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public bool value; // Determina si la condición debe cumplirse (true) o no cumplirse (false) para la transición

    // Método abstracto que verifica si la condición se cumple
    public abstract bool Check(GameObject owner);

    // Método abstracto para dibujar los Gizmos en la escena
    public virtual void DrawGizmos(GameObject owner)
    {
        // Este método puede ser sobreescrito en las clases derivadas para dibujar visualizaciones específicas
    }
}