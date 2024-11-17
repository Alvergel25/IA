using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State initialState;
    public State currenState;
    // Start is called before the first frame update
    void Start()
    {
        currenState = initialState;
    }

    // Update is called once per frame
    void Update()
    {
        State nextState = currenState.Run(gameObject);

        if (nextState)
        {
            currenState = nextState;
        }
    }

    public void OnDrawGizmos()
    {
        if (currenState)
            currenState.DrawAllActionsGizmos(gameObject);
        else if (initialState)
            initialState.DrawAllActionsGizmos(gameObject);
    }
}
