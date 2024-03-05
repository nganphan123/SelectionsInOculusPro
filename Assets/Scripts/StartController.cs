using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    public Text text;
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    void Update()
    {
        text.text = "Time complete task is " + Timer.endTime.Subtract(Timer.startTime).TotalMilliseconds.ToString() + " ms.";
    }
}
