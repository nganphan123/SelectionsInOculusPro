using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    [SerializeField]
    Text roundDisplay;
    // Start is called before the first frame update
    void Start()
    {
        roundDisplay.text = "Round " + RoundController.count;
    }
}
