using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class RoundController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cubes;
    [SerializeField]
    private FirebaseDbManager firebaseDbManager;
    public GameObject targetCube;
    public int totalAttemptsMade;
    public DateTime startTime;
    public DateTime endTime;
    public DateTime lastHoverTime;

    public static int count;
    public static int totalTrialsCount;
    void Start()
    {
        System.Random rnd = new System.Random();
        targetCube = cubes[rnd.Next(0, cubes.Length)];
        totalAttemptsMade = 0;
        startTime = DateTime.Now;
        switch (PlayerPrefs.GetInt("trialsCount"))
        {
            case 0:
                totalTrialsCount = 5;
                break;
            case 1:
                totalTrialsCount = 10;
                break;
            case 2:
                totalTrialsCount = 15;
                break;
        }
    }

    public void EndRound()
    {
        firebaseDbManager.AddRecord(totalAttemptsMade, startTime, endTime, lastHoverTime);
        // if all rounds are done, go back to start menu
        if (count == totalTrialsCount)
        {
            PlayerPrefs.SetString("roundCount", count.ToString());
            SceneManager.LoadScene("StartMenu");
        }
        else
        {
            count += 1;
            PlayerPrefs.SetString("roundCount", count.ToString());
            SceneManager.LoadScene("RoundStart");
        }
    }
}
