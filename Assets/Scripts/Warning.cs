using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject warning;

    public GameObject wall;

    public GameController gameController;


    private void OnTriggerEnter(Collider other)
    {
        if (gameController.caveOpen)
        {
            wall.SetActive(false);
        }

        else
        {
            warning.SetActive(true);
            gameController.PauseGame();
        }
    }




}
