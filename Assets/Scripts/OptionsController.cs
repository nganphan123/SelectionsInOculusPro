using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    public TMP_Dropdown technique;
    [SerializeField]
    public TMP_Dropdown speed;
    [SerializeField]
    public TMP_Dropdown size;
    [SerializeField]
    public TMP_Dropdown objNum;
    [SerializeField]
    public TMP_Dropdown selection;
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
        {1, 0.02f},
        {2, 0.03f},
    };
    public static Dictionary<int, float> sizeMap = new Dictionary<int, float>{
        {0, 01f},
        {1, 02f},
        {2, 03f}
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

    public void SetObjectNums()
    {
        PlayerPrefs.SetInt("objNum", objNum.value);
    }

    public void SetSelection()
    {
        PlayerPrefs.SetInt("selection", selection.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        technique.value = PlayerPrefs.GetInt("technique");
        speed.value = PlayerPrefs.GetInt("speed");
        size.value = PlayerPrefs.GetInt("size");
        objNum.value = PlayerPrefs.GetInt("objNum");
        selection.value = PlayerPrefs.GetInt("selection");
    }
}
