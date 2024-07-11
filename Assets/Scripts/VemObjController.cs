using UnityEngine;


public class VemObjController : MonoBehaviour
{
    [SerializeField]
    private GameObject vem2000;
    [SerializeField]
    private GameObject vem4000;
    [SerializeField]
    private GameObject vem6000;
    // Start is called before the first frame update
    void Start()
    {
        vem2000.SetActive(false);
        vem4000.SetActive(false);
        vem6000.SetActive(false);
        int size = PlayerPrefs.GetInt("vemSize");
        switch(size){
            case 0: vem2000.SetActive(true); break;
            case 1: vem4000.SetActive(true); break;
            case 2: vem6000.SetActive(true); break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}