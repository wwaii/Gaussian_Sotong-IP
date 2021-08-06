using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Daruk : MonoBehaviour
{

    // Have an Idle and a Patrolling state
    // In Idle state, it will stand still for a few seconds, before changing to Patrolling
    // In Patrolling state, it will move towards a defined checkpoint.
    // After it reaches the checkpoint, go back to Idle state.

    /// <summary>
    /// This stores the current state that the AI is in
    /// </summary>
    public string currentState;

    /// <summary>
    /// This stores the next state that the AI should transition to
    /// </summary>
    public string nextState;

    /// <summary>
    /// The NavMeshAgent component attached to the gameobject
    /// </summary>
    private NavMeshAgent agentComponent;

    /// <summary>
    /// The current player that is being seen by the AI
    /// </summary>
    public Transform target;
   
    public PlayerBehaviour connectedPlayer;

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
    }

    public void chaseBanana()
    {

    }

    /// <summary>
    /// The behaviour of the AI when in the Idle state
    /// </summary>
    /// <returns></returns>
    IEnumerator Idle()
    {
        while (currentState == "Idle")
        {
            // This while loop will contain the Idle behaviour

            // The AI will wait for a few seconds before continuing.
            yield return null;

            agentComponent.speed = 3.5f;

            // Change to Patrolling state.
            if (connectedPlayer.darukFollow)
            {
                nextState = "Following";
            }    
        }
    }

    /// <summary>
    /// The behaviour of the AI when in the Patrolling state
    /// </summary>
    /// <returns></returns>
    IEnumerator Following()
    {
        // Set the checkpoint that this AI should move towards
        
        bool hasReached = false;
        target = GameObject.Find("Player").transform;

        while (currentState == "Following")
        {
            // This while loop will contain the Patrolling behaviour
            agentComponent.SetDestination(target.position);
            yield return null;
            if (!hasReached)
            {
                agentComponent.speed -= Time.deltaTime/10;
                // If agent has not reached destination, do the following code
                // Check that the agent is at an acceptable stopping distance from the destination
                if (agentComponent.remainingDistance <= agentComponent.stoppingDistance)
                {
                    // We want to make sure this only happens once.
                    hasReached = true;
                    // Change back to Idle state.
                    nextState = "Idle";

                }
            }
        }
    }
}
