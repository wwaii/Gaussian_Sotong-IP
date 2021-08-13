using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    public void pipeRotate()
    {
        if (!PipeGame.completed)
        {
            transform.Rotate(0f, 0f, 90f);
        }
    }
}
