using System;
using UnityEngine;
using UnityEngine.Events;

// [RequireComponent(typeof(Collider))]
// [RequireComponent(typeof(Rigidbody))]
public class CursorController : MonoBehaviour
{
    [field: SerializeField]
    public bool IsHovered { get; private set; }
    [field: SerializeField]
    public float speed;

    private Vector3 leftHit;
    private Vector3 rightHit;
    private Renderer renderer;
    private Vector3 targetPosition;
    private bool isEyeInteractor;
    
    // Start is called before the first frame update
    void Start()
    {
        int techniqueOption = PlayerPrefs.GetInt("technique");
        isEyeInteractor = techniqueOption == 1 || techniqueOption == 2; 
        renderer = transform.GetComponent<Renderer>();
        renderer.enabled = false;
    }

    public void Hover(bool state)
    {
        Debug.Log("set hover" + state);
        IsHovered = state;
    }

    public void SetLeftHit(Vector3 point){
        leftHit = point;
    }
    
    public void SetRightHit(Vector3 point){
        rightHit = point;
    }

    // Update is called once per frame
    void Update()
    {
        renderer.enabled = IsHovered;

        if(IsHovered){
            if(isEyeInteractor){
                // find middle point
                targetPosition = (leftHit + rightHit) / 2.0f;
            }else{
                targetPosition = rightHit;
            }
            var step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }
}
