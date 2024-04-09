using UnityEngine;
using Firebase.Database;
using Firebase.Extensions;
using System.Collections.Generic;
using System;

public class FirebaseDbManager : MonoBehaviour
{
    DatabaseReference mDatabase;
    // Start is called before the first frame update
    void Start()
    {
        // connect to db
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                mDatabase = FirebaseDatabase.DefaultInstance.RootReference;
                Debug.Log("Successfully connect to Firebase");
            }
            else
            {
                Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
            }
        });


    }

    public void AddRecord(int totalAttempts, DateTime startTime, DateTime endTime, DateTime lastHoverTime)
    {
        OptionsController.techniqueMap.TryGetValue(PlayerPrefs.GetInt("technique"), out string technique);
        OptionsController.speedMap.TryGetValue(PlayerPrefs.GetInt("speed"), out float speed);
        OptionsController.sizeMap.TryGetValue(PlayerPrefs.GetInt("size"), out float size);
        OptionsController.selectionMap.TryGetValue(PlayerPrefs.GetInt("selection"), out string selection);

        Debug.Log($"Record:: Speed: {speed}, size: {size}, selection: {selection}, tech: {technique}");

        string key = mDatabase.Push().Key;
        float errorRate = (1 - 1.0f / totalAttempts) * 100;
        RecordEntry entry = new(totalAttempts, errorRate.ToString("000.00"), technique, selection, size.ToString("0.0"), speed.ToString("0.0000"), endTime.Subtract(startTime).TotalMilliseconds.ToString(), lastHoverTime.Subtract(startTime).TotalMilliseconds.ToString());
        Dictionary<string, object> entryValues = entry.ToDictionary();

        Dictionary<string, object> childUpdates = new()
        {
            [key] = entryValues
        };
        mDatabase.UpdateChildrenAsync(childUpdates).ContinueWithOnMainThread((task) =>
        {
            if (task.Exception != null)
            {
                Debug.Log($"Firebase Exception: {task.Exception}");
            }
        });
    }
}

public class RecordEntry
{
    public string technique, selection, time, speed, size, errorRate, lastHoverTime;
    public int totalAttempts;
    public RecordEntry(int totalAttempts, string errorRate, string technique, string selection, string size, string speed, string time, string lastHoverTime)
    {
        this.technique = technique;
        this.speed = speed;
        this.size = size;
        this.selection = selection;
        this.time = time;
        this.totalAttempts = totalAttempts;
        this.errorRate = errorRate;
        this.lastHoverTime = lastHoverTime;
    }

    public Dictionary<string, object> ToDictionary()
    {
        Dictionary<string, object> result = new Dictionary<string, object>();
        result["speed"] = speed;
        result["selection"] = selection;
        result["technique"] = technique;
        result["size"] = size;
        result["time"] = time;
        result["erroRate"] = errorRate;
        result["attempts"] = totalAttempts;
        result["last hover time"] = lastHoverTime;

        return result;
    }
}
