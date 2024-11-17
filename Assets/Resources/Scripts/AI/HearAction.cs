using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HearAction (A)", menuName = "ScriptableObjects/Actions/HearAction")]

public class HearAction : Action
{
    public float radius = 20f;
    public override bool Check(GameObject owner)
    {
        RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position, radius, Vector3.up); //Castea una esfera con el radio asignado

        GameObject target = owner.GetComponent<TargetReference>().target; //Acedemos al target

        foreach (RaycastHit hit in hits) //Escuchamos
        {
            if (hit.collider.gameObject == target) //Si alguno de los objetos que escuchamos es la esfera entonces true, sino no
            {
                // Le hemos escuchado / olido
                return true;
            }
        }

        return false; //no le escucho
    }

    public override void DrawGizmos(GameObject owner)
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(owner.transform.position, radius);
    }
}
