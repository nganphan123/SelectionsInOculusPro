using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    public TMP_Dropdown technique;
    [SerializeField]
    public TMP_Dropdown speed;
    [SerializeField]
    public TMP_Dropdown size;
    [SerializeField]
    public TMP_Dropdown selection;
    [SerializeField]
    public Toggle practiceMode;

    [SerializeField]
    public TMP_Dropdown uid;
    public static Dictionary<int, string> techniqueMap = new Dictionary<int, string>{
        {0, "head"},
        {1, "eye"},
        {2, "head range and eye gaze"}
    };
    public static Dictionary<int, string> selectionMap = new Dictionary<int, string>{
        {0, "hand pinching"},
        {1, "right eye blinking"},
    };
    public static Dictionary<int, float> speedMap = new Dictionary<int, float>{
        {0, 0.01f},
        {1, 0.03f},
    };
    public static Dictionary<int, float> sizeMap = new Dictionary<int, float>{
        {0, 0.1f},
        {1, 0.2f},
    };

    public void SetSpeed()
    {
        PlayerPrefs.SetInt("speed", speed.value);
    }
    public void SetTechnique()
    {
        PlayerPrefs.SetInt("technique", technique.value);
    }
    public void SetObjectSize()
    {
        PlayerPrefs.SetInt("size", size.value);
    }
    public void SetSelection()
    {
        PlayerPrefs.SetInt("selection", selection.value);
    }

    public void SetUid()
    {
        PlayerPrefs.SetInt("uid", uid.value);
    }

    public void SetPracticeMode()
    {
        PlayerPrefs.SetInt("onPractice", practiceMode.isOn ? 1 : 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        technique.value = PlayerPrefs.GetInt("technique");
        speed.value = PlayerPrefs.GetInt("speed");
        size.value = PlayerPrefs.GetInt("size");
        selection.value = PlayerPrefs.GetInt("selection");
        uid.value = PlayerPrefs.GetInt("uid");
        PlayerPrefs.SetInt("onPractice", practiceMode.isOn ? 1 : 0);
        // reset count to 1 to start new round group
        RoundController.count = 1;
    }
}
