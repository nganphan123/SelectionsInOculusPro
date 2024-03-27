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
        // if(PlayerPrefs.GetInt("technique"))
        // PlayerPrefs.SetInt("technique", 0);
        // PlayerPrefs.SetInt("size", 0);
        // PlayerPrefs.SetInt("speed", 0);
        technique.value = PlayerPrefs.GetInt("technique");
        speed.value = PlayerPrefs.GetInt("speed");
        size.value = PlayerPrefs.GetInt("size");
        objNum.value = PlayerPrefs.GetInt("objNum");
        selection.value = PlayerPrefs.GetInt("selection");
    }
}
