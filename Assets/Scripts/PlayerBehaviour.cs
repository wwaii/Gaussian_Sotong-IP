using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Camera playerCamera;

    public int interactionDistance;
    void Update()
    {
        InteractionRaycast();
    }

    private void InteractionRaycast()
    {
        Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.position + playerCamera.transform.forward * interactionDistance);
        int layerMask = 1 << LayerMask.NameToLayer("IntObject");

        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, interactionDistance, layerMask))
        {
            Debug.Log(hitInfo.transform.name);

            if (Input.GetKeyDown(KeyCode.E))
            {

            }
        }
    }



}
