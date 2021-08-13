using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public GameController gameController;

    public GameObject firstItem;

    public GameObject hotbarItem;
    public void Collected()
    {
        if (gameController.potionFirstTime)
        {
            hotbarItem.SetActive(true);
            firstItem.SetActive(true);
            gameController.PauseGame();
            gameController.potionFirstTime = false;
        }

        gameObject.SetActive(false);

        gameController.potionCount += 1;
    }
}
