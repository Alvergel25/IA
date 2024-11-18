using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachineMonster : MonoBehaviour
{
    //perseguir
    public Transform playerTransform;
    public float maxTime = 1.0f, maxDistance = 1.0f;

    NavMeshAgent agent;
    Animator animator;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            float sqDistance = (playerTransform.position - agent.destination).sqrMagnitude;
            if (sqDistance > maxDistance * maxDistance)
            {
                //Perseguir al jugador
                agent.destination = playerTransform.position;
            }
            timer = maxTime;
        }

        animator.SetFloat("Velocity", agent.velocity.magnitude);
    }
}
