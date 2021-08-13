using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameController gameController;

    public Transform teleportTarget;

    public GameObject thePlayer;

    public GameObject daruk;

    public GameObject darukForest;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        // tell AI to chase
        if (other.tag == "Player")
        {
            thePlayer.transform.position = teleportTarget.transform.position;

            if (!gameController.darukStopFollow)
            {
                daruk.SetActive(false);
                darukForest.SetActive(true);
            }
            else
            {
                daruk.SetActive(true);
                darukForest.SetActive(false);
            }
        }
    }
}
