using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public TMP_Dropdown technique;
    public TMP_Dropdown speed;
    public TMP_Dropdown size;
    public TMP_Dropdown selection;
    public Toggle practiceMode;
    public TMP_Dropdown uid;
    public TMP_Dropdown vem;
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
        {0, 2f},
        {1, 5f},
    };
    public static Dictionary<int, float> sizeMap = new Dictionary<int, float>{
        {0, 0.1f},
        {1, 0.3f},
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

    public void SetVemDisplay(){
        PlayerPrefs.SetInt("vemType", vem.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        technique.value = PlayerPrefs.GetInt("technique");
        speed.value = PlayerPrefs.GetInt("speed");
        size.value = PlayerPrefs.GetInt("size");
        selection.value = PlayerPrefs.GetInt("selection");
        uid.value = PlayerPrefs.GetInt("uid");
        vem.value = PlayerPrefs.GetInt("vemType");
        PlayerPrefs.SetInt("onPractice", practiceMode.isOn ? 1 : 0);
        // reset count to 1 to start new round group
        RoundController.count = 1;
    }
}
