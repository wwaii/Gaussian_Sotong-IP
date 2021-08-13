using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionField : MonoBehaviour
{
    // When player enters the trigger, tell AI to chase
    // When player leaves the trigger, tell AI to sop chasing

    /// <summary>
    /// Stores the AI that this VisionField should update
    /// </summary>

    public Chicken chicken;

    public GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        // tell AI to chase
        if (other.tag == "Player")
        {
            if (gameController.seedCount  > 0)
            {
                chicken.SeePlayer(other.transform);
            }
            // Passes the seen player to the AI via the SeePlayer function
            Debug.Log("seen");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // tell AI to stop
        if (other.tag == "Player")
        {
            // Tells the AI that the player was lost
            chicken.LostPlayer();
        }
    }
}
