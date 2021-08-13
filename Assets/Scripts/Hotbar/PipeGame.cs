using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGame : MonoBehaviour
{
    public Transform[] pipes;

    public static bool completed;

    public GameObject nextButton;

    // Start is called before the first frame update
    void Start()
    {
        completed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pipes[0].rotation.z == 0 &&
            pipes[1].rotation.z == 0 &&
            pipes[2].rotation.z == 0 &&
            pipes[3].rotation.z == 0 &&
            pipes[4].rotation.z == 0 &&
            pipes[5].rotation.z == 0 &&
            pipes[6].rotation.z == 0 &&
            pipes[7].rotation.z == 0 &&
            pipes[8].rotation.z == 0 &&
            pipes[9].rotation.z == 0 &&
            pipes[10].rotation.z == 0 &&
            pipes[11].rotation.z == 0 &&
            pipes[12].rotation.z == 0 &&
            pipes[13].rotation.z == 0)
        {
            completed = true;
            nextButton.SetActive(true);
        }
    }
}
