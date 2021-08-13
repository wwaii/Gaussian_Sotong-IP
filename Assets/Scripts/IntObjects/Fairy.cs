using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public GameObject talkingPartOne;

    public GameController gameController;
    public void talk()
    {
        talkingPartOne.SetActive(true);
        gameController.PauseGame();

    }
}
