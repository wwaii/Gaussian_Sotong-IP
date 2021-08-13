using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    public GameController gameController;

    public GameObject firstItem;

    public GameObject hotbarItem;

    public void Collected()
    {
        if (gameController.woodFirstTime)
        {
            hotbarItem.SetActive(true);
            firstItem.SetActive(true);
            gameController.PauseGame();
            gameController.woodFirstTime = false;
        }

        gameObject.SetActive(false);

        gameController.woodCount += 5;
    }
}
