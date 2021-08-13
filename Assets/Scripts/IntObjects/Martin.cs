using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martin : MonoBehaviour
{
    public GameObject talkingPartOne;
    public GameObject talkingPartTwo;
    public GameObject talkingPartThree;
    public GameController gameController;
    public void talk()
    {
        talkingPartOne.SetActive(true);
        gameController.PauseGame();

    }

    public void talkTwo()
    {
        talkingPartTwo.SetActive(true);
        gameController.PauseGame();
        gameController.mushroomsCount -= 3;
    }

    public void talkThree()
    {
        talkingPartThree.SetActive(true);
        gameController.PauseGame();
    }
}
