using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
    public float wanderRadius;

    public string currentState;

    public string nextState;

    [SerializeField]
    private float idleTime;

    public Transform target;

    private NavMeshAgent agentComponent;

    private void Awake()
    {
        // Get the attached NavMeshAgent and store it in agentComponent
        agentComponent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Set the starting state as Idle
        nextState = "Idle";
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the AI should change to a new state
        if (nextState != currentState)
        {
            // Stop the current running coroutine first before starting a new one.
            StopCoroutine(currentState);
            currentState = nextState;
            StartCoroutine(currentState);
        }

       
        //set timer (2val, currentime and cooldown)
        //when player hit chicken , currenttime = 0
        //player move away, += deltatime (cooldown) until = cooldown
        //when both = , do condition
    }


    /// <summary>
    /// The behaviour of the AI when in the Idle state
    /// </summary>
    /// <returns></returns>
    IEnumerator Idle()
    {
        idleTime = Random.Range(5, 12);
        while (currentState == "Idle")
        {
            // This while loop will contain the Idle behaviour

            // The AI will wait for a few seconds before continuing.
            yield return new WaitForSeconds(idleTime);
                     
            // Change to Patrolling state.
            nextState = "Wandering";

        }
    }

    IEnumerator Wandering()
    {

        idleTime = 2;
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
        agentComponent.SetDestination(newPos);
        yield return new WaitForSeconds(idleTime);
        nextState = "Idle";
    }

    IEnumerator ChasingPlayer()
    {
        while (currentState == "ChasingPlayer")
        {
            // This while loop will contain the ChasingPlayer behaviour

            yield return null;

            // If there is a player to chase, keep chasing the player
            if (target != null)
            {
                agentComponent.SetDestination(target.position);
            }
            // If not, move back to the Idle state
            else
            {
                nextState = "Idle";
            }
        }
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    public void SeePlayer(Transform seenPlayer)
    {
        // Store the seen player and change the state of the AI
        target = seenPlayer;
        nextState = "ChasingPlayer";
    }

    /// <summary>
    /// Used to tell the AI that it lost the player
    /// </summary>
    public void LostPlayer()
    {
        // Set the seen player to null
        target = null;
    }




}