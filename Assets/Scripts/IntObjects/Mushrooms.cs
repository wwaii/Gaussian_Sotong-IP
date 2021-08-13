using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushrooms : MonoBehaviour
{
    public GameController gameController;

    public GameObject firstItem;

    public GameObject hotbarItem;

    public void Collected()
    {
        if (gameController.mushroomFirstTime)
        {
            hotbarItem.SetActive(true);
            firstItem.SetActive(true);
            gameController.PauseGame();
            gameController.mushroomFirstTime = false;
        }

        gameObject.SetActive(false);

        gameController.mushroomsCount += 1;
    }
}
