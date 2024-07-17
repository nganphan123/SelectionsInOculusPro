using UnityEngine;


public class VemObjController : MonoBehaviour
{
    [SerializeField]
    private GameObject vem2000;
    [SerializeField]
    private GameObject vem4000;
    [SerializeField]
    private GameObject vem6000;
    [SerializeField]
    private GameObject vemFlat;
    // Start is called before the first frame update
    void Start()
    {
        vem2000.SetActive(false);
        vem4000.SetActive(false);
        vem6000.SetActive(false);
        vemFlat.SetActive(false);
        int type = PlayerPrefs.GetInt("vemType");
        switch(type){
            case 0: vem2000.SetActive(true); break;
            case 1: vem4000.SetActive(true); break;
            case 2: vem6000.SetActive(true); break;
            case 3: vemFlat.SetActive(true); break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
