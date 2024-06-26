using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

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
    public static int totalTrialsCount = 10;
    public static List<Record> records = new List<Record>();
    void Start()
    {
        System.Random rnd = new System.Random();
        targetCube = cubes[rnd.Next(0, cubes.Length)];
        totalAttemptsMade = 0;
        startTime = DateTime.Now;
    }

    public void EndRound()
    {
        Record record = new Record(totalAttemptsMade, startTime, endTime, lastHoverTime);
        records.Add(record);
        // if all rounds are done, go back to start menu
        if (count == totalTrialsCount)
        {
            if (PlayerPrefs.GetInt("onPractice") != 1)
            {
                firebaseDbManager.AddCombo(records);
            }
            PlayerPrefs.SetString("roundCount", count.ToString());
            records.Clear();
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

public class Record
{
    public int totalAttemptsMade;
    public DateTime startTime;
    public DateTime endTime;
    public DateTime lastHoverTime;
    public Record(int totalAttemptsMade, DateTime startTime, DateTime endTime, DateTime lastHoverTime)
    {
        this.totalAttemptsMade = totalAttemptsMade;
        this.startTime = startTime;
        this.endTime = endTime;
        this.lastHoverTime = lastHoverTime;
    }
}
