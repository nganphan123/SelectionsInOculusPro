using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class RoundController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cubes;
    [SerializeField]
    private FirebaseDbManager firebaseDbManager;
    public static GameObject targetCube;

    public static int count;
    public int totalTrialsCount;
    public static DateTime startTime;
    public static DateTime endTime;
    void Start()
    {
        System.Random rnd = new System.Random();
        targetCube = cubes[rnd.Next(0, cubes.Length)];
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
        Debug.Log("count option " + PlayerPrefs.GetInt("trialsCount"));
    }

    public void EndRound()
    {
        Debug.Log("current count " + count);
        Debug.Log("count option " + totalTrialsCount);
        firebaseDbManager.AddRecord();
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
