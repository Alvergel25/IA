using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public bool value; //Si la ccion tiene o no que cumplirse

    public abstract bool Check(GameObject owner); //En el check lo que va ha hacer es ejecutar el comportamiento de la accion

    public abstract void DrawGizmos(GameObject owner);
}
