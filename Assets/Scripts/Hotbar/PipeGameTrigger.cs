using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGameTrigger : MonoBehaviour
{
    public GameController gameController;

    public GameObject pipeGame;

    private void Start()
    {
        pipeGame.SetActive(false);
    }

    public void OpenGame()
    {
        pipeGame.SetActive(true);

        gameController.PauseGame();
    }

}
