using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public Transform[] targets;
    public NavMeshAgent agent;
    private int currentTargetIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent
        <NavMeshAgent>();
        SetDestination(targets[currentTargetIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the agent has reached the current target
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            // Move to the next target
            currentTargetIndex = (currentTargetIndex + 1) % targets.Length;
            SetDestination(targets[currentTargetIndex].position);
        }
    }

    void SetDestination(Vector3 destination)
    {
        agent.destination = destination;
    }
}
