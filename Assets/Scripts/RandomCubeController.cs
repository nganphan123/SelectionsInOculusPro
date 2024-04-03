using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RandomCubeController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cubes;
    [SerializeField]
    private FirebaseDbManager firebaseDbManager;
    public Text countText;

    public int count;
    public static GameObject targetCube;
    void Start()
    {
        int objNumOpt = PlayerPrefs.GetInt("objNum");
        switch (objNumOpt)
        {
            case 0:
                count = 5;
                break;
            case 1:
                count = 10;
                break;
            default:
                count = 15;
                break;
        }
        // foreach (GameObject cube in cubes)
        // {
        //     cube.SetActive(false);
        // }
        // int sizeOpt = PlayerPrefs.GetInt("size");
        // Vector3 newSize;
        // switch (sizeOpt)
        // {
        //     case 0:
        //         newSize = new Vector3(0.1f, 0.1f, 0.1f);
        //         break;
        //     case 1:
        //         newSize = new Vector3(0.2f, 0.2f, 0.2f);
        //         break;
        //     default:
        //         newSize = new Vector3(0.3f, 0.3f, 0.3f);
        //         break;

        // }
        // // change cubes size
        // foreach (GameObject cube in cubes)
        // {
        //     cube.transform.localScale = newSize;
        // }
        RandomCube();
        Timer.startTime = DateTime.Now;
    }

    public void RandomCube()
    {
        if (count == 0)
        {
            Timer.endTime = DateTime.Now;
            firebaseDbManager.AddRecord();
            SceneManager.LoadScene("StartMenu");
        }
        else
        {
            count -= 1;
            System.Random rnd = new System.Random();
            targetCube = cubes[rnd.Next(0, cubes.Length)];
        }
        countText.text = "Number of selections left " + count;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
