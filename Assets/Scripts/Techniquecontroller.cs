using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Techniquecontroller : MonoBehaviour
{
    [SerializeField]
    private GameObject HeadInteractor;
    [SerializeField]
    private GameObject LeftEyeInteractor;
    [SerializeField]
    private GameObject RightEyeInteractor;
    [SerializeField]
    private GameObject HeadRange;
    [SerializeField]
    private GameObject HandRayInteractor;
    // Start is called before the first frame update
    void Start()
    {
        HeadInteractor.SetActive(false);
        LeftEyeInteractor.SetActive(false);
        RightEyeInteractor.SetActive(false);
        HeadRange.SetActive(false);
        // HandRayInteractor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        int technique = PlayerPrefs.GetInt("technique");
        switch (technique)
        {
            case 0:
                HeadInteractor.SetActive(true);
                break;
            case 1:
                LeftEyeInteractor.SetActive(true);
                RightEyeInteractor.SetActive(true);
                break;
            case 2:
                HeadRange.SetActive(true);
                LeftEyeInteractor.SetActive(true);
                RightEyeInteractor.SetActive(true);
                break;
            default:
                HeadInteractor.SetActive(true);
                break;
                // default:
                //     HandRayInteractor.SetActive(true);
                //     break;
        }
    }
}
