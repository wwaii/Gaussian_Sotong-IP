using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetactField : MonoBehaviour
{
    // When player enters the trigger, tell AI to chase
    // When player leaves the trigger, tell AI to sop chasing

    /// <summary>
    /// Stores the AI that this VisionField should update
    /// </summary>
    [SerializeField]
    private Daruk daruk;


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Banana")
        {
            Debug.Log(other.name);

        }
    }

}
