using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ActionParameters
{
    [Tooltip("Action that is gonna be executed")]
    public Action action; // Acción que se va a ejecutar
    [Tooltip("Indicates if the action's check must be true or false")]
    public bool actionValue; // Indica si el resultado de la acción debe ser verdadero o falso para cumplir la condición
}

[System.Serializable]
public struct StateParameters
{
    [Tooltip("ActionParameters' array")]
    public ActionParameters[] actionParameters; // Array de condiciones que se deben verificar para cambiar de estado
    [Tooltip("If the action's check equals actionValue, next state is activated")]
    public State nextStates; // El siguiente estado al que se cambiará si se cumplen las condiciones
    [Tooltip("All actions are executed or just one")]
    public bool and; // Si es verdadero, todas las condiciones deben cumplirse; si es falso, solo una debe cumplirse (equivale a 'or')
}

// Clase base `State`, representa un estado abstracto que otros estados específicos pueden heredar
public abstract class State : ScriptableObject
{
    public StateParameters[] stateParameters; // Condiciones de transición y siguientes estados posibles

    // Método llamado al entrar en el estado
    public virtual void OnEnter(GameObject owner)
    {
        // Lógica que se debe ejecutar cuando se entra en el estado
        Debug.Log("Entering state: " + this.GetType().Name);
    }

    // Método llamado al salir del estado
    public virtual void OnExit(GameObject owner)
    {
        // Lógica que se debe ejecutar cuando se sale del estado
        Debug.Log("Exiting state: " + this.GetType().Name);
    }

    // Verifica si se cumplen las condiciones para cambiar de estado
    protected State CheckActions(GameObject owner)
    {
        // Recorre cada conjunto de condiciones en `stateParameters`
        for (int i = 0; i < stateParameters.Length; i++)
        {
            bool allActionsMet = true;

            // Recorre todas las acciones dentro del conjunto de condiciones
            for (int j = 0; j < stateParameters[i].actionParameters.Length; j++)
            {
                ActionParameters actionParam = stateParameters[i].actionParameters[j];

                // Ejecuta la acción y compara el resultado con `actionValue`
                bool actionResult = actionParam.action.Check(owner.gameObject);
                if (actionResult == actionParam.actionValue)
                {
                    // Si se cumple una condición y `and` es falso, retorna el siguiente estado inmediatamente
                    if (!stateParameters[i].and)
                    {
                        return stateParameters[i].nextStates;
                    }
                }
                else if (stateParameters[i].and)
                {
                    // Si `and` es verdadero y una acción no se cumple, marca `allActionsMet` como falso
                    allActionsMet = false;
                    break;
                }
            }

            // Si `and` es verdadero y todas las acciones se cumplen, retorna el siguiente estado
            if (stateParameters[i].and && allActionsMet)
            {
                return stateParameters[i].nextStates;
            }
        }

        // Ninguna condición de transición se cumple, retorna `null` para mantener el estado actual
        return null;
    }

    // Ejecuta la acción específica del estado y verifica si debe hacer una transición
    public virtual State Run(GameObject owner)
    {
        PerformAction(owner); // Ejecuta la lógica principal del estado
        return CheckActions(owner); // Verifica condiciones de transición y retorna el siguiente estado si corresponde
    }

    // Método abstracto para definir la acción específica de cada estado en clases derivadas
    protected abstract void PerformAction(GameObject owner);

    // Dibuja Gizmos de depuración para cada acción en el estado
    public void DrawAllActionsGizmos(GameObject owner)
    {
        foreach (StateParameters parameter in stateParameters)
        {
            foreach (ActionParameters aP in parameter.actionParameters)
            {
                aP.action.DrawGizmos(owner);
            }
        }
    }
}
