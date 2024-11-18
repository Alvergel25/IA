using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public bool value; // Determina si la condici�n debe cumplirse (true) o no cumplirse (false) para la transici�n

    // M�todo abstracto que verifica si la condici�n se cumple
    public abstract bool Check(GameObject owner);

    // M�todo abstracto para dibujar los Gizmos en la escena
    public virtual void DrawGizmos(GameObject owner)
    {
        // Este m�todo puede ser sobreescrito en las clases derivadas para dibujar visualizaciones espec�ficas
    }
}