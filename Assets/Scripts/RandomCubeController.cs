using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class RandomCubeController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cubes;
    // [SerializeField]
    // private EyeInteractable cube1;
    // [SerializeField]
    // private EyeInteractable cube2;
    // [SerializeField]
    // private EyeInteractable cube3;
    // [SerializeField]
    // private EyeInteractable cube4;
    // [SerializeField]
    // private EyeInteractable cube5;
    // [SerializeField]
    // private EyeInteractable cube6;
    // [SerializeField]
    // private EyeInteractable cube7;
    // [SerializeField]
    // private EyeInteractable cube8;
    // Start is called before the first frame update
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
            SceneManager.LoadScene("StartMenu");
        }
        else
        {
            count -= 1;
            System.Random rnd = new System.Random();
            targetCube = cubes[rnd.Next(0, cubes.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
