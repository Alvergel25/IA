using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ActionParameters
{
    [Tooltip("Action that is gonna be executed")]
    public Action action;
    [Tooltip("Indicates if the action's check must be true or false")]
    public bool actionValue;
}


[System.Serializable]
public struct StateParameters
{
    [Tooltip("ActionParameters' array")]
    public ActionParameters[] actionParameters;
    [Tooltip("If the action's check equeals actionValue, next is puched")] //Los tooltips ponen tips cuando pones el cursor encima
    public State nextStates;
    [Tooltip("All actions are executed or just one")]
    public bool and;
}

public abstract class State : ScriptableObject
{
    public StateParameters[] stateParameters;

    protected State CheckActions(GameObject owner)
    {
        //recorre todo el array
        //devolvera el siguiente estado que toque si alguna de sus acciones se cumple, o null si es al contrario
        for (int i = 0; i < stateParameters.Length; i++)
        {
            bool AllActions = true;
            for (int j = 0; j < stateParameters[i].actionParameters.Length; j++)
            {
                ActionParameters actionParameters = stateParameters[i].actionParameters[j];
                //if (actionParameters.action.Check(owner) == actionParameters.actionValue)
                //{
                //    if (!stateParameters[i].and) //Si solo se tiene que cumplir una
                //    {
                //        //devolvemos directamente el siguiente estado
                //        return stateParameters[i].nextStates;
                //    }
                //}
                //else if (stateParameters[i].and)
                //{
                //    AllActions = false;
                //    break;//Salimos del bucle porque una accion no se a cumplido y estamos en and
                //}
            }
            if (stateParameters[i].and && AllActions)
            {
                return stateParameters[i].nextStates;
            }
        }

        return null; //ninguna accion se cumple, por lo que no cambia de estado
    }

    // Comprueba si las acciones se cumplen y ademas, ejecuta el comportamiento asociado al estado
    public abstract State Run(GameObject owner);

    public void DrawAllActionsGizmos(GameObject owner)
    {
        foreach (StateParameters parameter in stateParameters)
        {
            foreach (ActionParameters aP in parameter.actionParameters)
            {
                //aP.action.DrawGizmos(owner);
            }
        }
    }
}
