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

    public void AddCombo(List<Record> records)
    {
        OptionsController.techniqueMap.TryGetValue(PlayerPrefs.GetInt("technique"), out string technique);
        OptionsController.speedMap.TryGetValue(PlayerPrefs.GetInt("speed"), out float speed);
        OptionsController.sizeMap.TryGetValue(PlayerPrefs.GetInt("size"), out float size);
        OptionsController.selectionMap.TryGetValue(PlayerPrefs.GetInt("selection"), out string selection);
        string uid = PlayerPrefs.GetInt("uid").ToString();
        DatabaseReference userRecord = mDatabase.Child(uid);
        string comboKey = userRecord.Push().Key;
        OptionsConfig optionsConfig = new OptionsConfig(size.ToString("0.0"), technique, speed.ToString("0.0000"), selection);
        Dictionary<string, object> optionsEntry = optionsConfig.ToDictionary();
        Dictionary<string, object> childUpdates = new()
        {
            [comboKey] = optionsEntry
        };
        userRecord.UpdateChildrenAsync(childUpdates).ContinueWithOnMainThread((task) =>
        {
            if (task.Exception != null)
            {
                Debug.Log($"Firebase Exception: {task.Exception}");
            }
        });

        for (int i = 0; i < records.Count; i += 1)
        {
            Record singleRec = records[i];
            DatabaseReference roundRecord = userRecord.Child(comboKey).Child("rounds");
            float errorRate = (1 - 1.0f / singleRec.totalAttemptsMade) * 100;
            string timeNeeded = singleRec.endTime.Subtract(singleRec.startTime).TotalMilliseconds.ToString();
            SingleRound r = new SingleRound(errorRate.ToString("000.00"), singleRec.lastHoverTime.Subtract(singleRec.startTime).TotalMilliseconds.ToString(), singleRec.totalAttemptsMade, timeNeeded);
            Dictionary<string, object> roundsEntry = r.ToDictionary();
            childUpdates = new()
            {
                [i.ToString()] = roundsEntry
            };
            roundRecord.UpdateChildrenAsync(childUpdates).ContinueWithOnMainThread((task) =>
        {
            if (task.Exception != null)
            {
                Debug.Log($"Firebase Exception in add records: {task.Exception}");
            }
        });
        }
    }

    public class SingleRound
    {
        public string errorRate, lastHoverTime, totalTime;
        public int totalAttempts;
        public SingleRound(string errorRate, string lastHoverTime, int totalAttempts, string time)
        {
            this.errorRate = errorRate;
            this.lastHoverTime = lastHoverTime;
            this.totalAttempts = totalAttempts;
            this.totalTime = time;
        }
        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result["errorRate"] = errorRate;
            result["lastHoverTime"] = lastHoverTime;
            result["totalAttempts"] = totalAttempts;
            result["totalTime"] = totalTime;
            return result;
        }
    }

    public class OptionsConfig
    {
        public string size, technique, speed, selection;
        public OptionsConfig(string size, string technique, string speed, string selection)
        {
            this.technique = technique;
            this.speed = speed;
            this.size = size;
            this.selection = selection;
        }

        public Dictionary<string, object> ToDictionary()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result["speed"] = speed;
            result["selection"] = selection;
            result["technique"] = technique;
            result["size"] = size;
            return result;
        }
    }
}
