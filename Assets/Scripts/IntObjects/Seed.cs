using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public GameController gameController;

    public GameObject firstItem;

    public GameObject hotbarItem;
    public void Collected()
    {
        if (gameController.seedFirstTime)
        {
            hotbarItem.SetActive(true);
            firstItem.SetActive(true);
            gameController.PauseGame();
            gameController.seedFirstTime = false;
        }

        gameObject.SetActive(false);

        gameController.seedCount += 1;
    }
}
