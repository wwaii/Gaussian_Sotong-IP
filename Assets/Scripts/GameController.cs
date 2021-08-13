using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int fishCount = 0;
    public bool fishFirstTime = true;
    public int mushroomsCount = 0;
    public bool mushroomFirstTime = true;
    public int woodCount = 0;
    public bool woodFirstTime = true;
    public int seedCount = 0;
    public bool seedFirstTime = true;
    public int potionCount = 0;
    public bool potionFirstTime = true;

    public bool caveOpen = false;

    public int missionDone = 0;

    public bool darukMissionStart = false;
    public bool michealMissionStart = false;
    public bool martinMissionStart = false;
    public bool darukStopFollow = false;
    public bool miphaFollow = false;
    private void Start()
    {
        PauseGame();
    }

    private void Update()
    {
        if (potionCount > 0)
        {
            miphaFollow = true;
        }
        if (missionDone >= 2)
        {
            caveOpen = true;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
