using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    [Header("Initial State")]
    public State initialState;   // Estado inicial
    public State currentState;   // Estado actual en el que se encuentra el enemigo

    [Header("Detection Distances")]
    public float detectionD;      // Distancia para detectar al jugador
    public float followD;         // Distancia para perseguir al jugador
    public float attackD;         // Distancia para atacar al jugador
    public float distractD;       // Distancia para distraerse si ocurre un evento espec�fico

    void Start()
    {
        // Comienza en el estado inicial y llama a OnEnter si est� configurado
        currentState = initialState;
        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }


    private void OnDrawGizmosSelected()
    {
        // Dibuja esferas de colores para visualizar los rangos de detecci�n
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionD); // Rango de detecci�n
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followD);    // Rango de persecuci�n
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackD);    // Rango de ataque
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distractD);  // Rango de distracci�n
    }

    void Update()
    {
        if (currentState != null)
        {
            // Ejecuta la l�gica del estado actual y verifica si se requiere una transici�n
            State nextState = currentState.Run(this);

            // Si el estado actual devuelve un nuevo estado, se realiza la transici�n
            if (nextState != null && nextState != currentState)
            {
                currentState.OnExit(this);  // Salir del estado actual
                currentState = nextState;   // Cambiar al nuevo estado
                currentState.OnEnter(this); // Entrar en el nuevo estado
            }
        }
    }

}