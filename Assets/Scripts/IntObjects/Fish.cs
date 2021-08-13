using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fish : MonoBehaviour
{
    public float wanderRadius;

    public string currentState;

    public string nextState;

    private NavMeshAgent agentComponent;

    public GameController gameController;

    public GameObject firstItem;

    public GameObject hotbarItem;

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
    IEnumerator Idle()
    {
        while (currentState == "Idle")
        {
            // This while loop will contain the Idle behaviour

            // The AI will wait for a few seconds before continuing.
            yield return null;

            // Change to Patrolling state.
            nextState = "Wandering";

        }
    }

    IEnumerator Wandering()
    {
        Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
        agentComponent.SetDestination(newPos);
        yield return null;
        nextState = "Idle";
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    public void GotCaught()
    {
        if (gameController.fishFirstTime)
        {
            hotbarItem.SetActive(true);
            firstItem.SetActive(true);
            gameController.PauseGame();
            gameController.fishFirstTime = false;
        }
        gameObject.SetActive(false);
        gameController.fishCount += 1;
    }
}
