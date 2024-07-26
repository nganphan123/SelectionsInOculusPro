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
        Vector3 newTargetPos;
        if(IsHovered){
            if(isEyeInteractor){
                // find middle point
                newTargetPos = Vector3.Lerp(leftHit, rightHit, 0.5f);
            }else{
                newTargetPos = rightHit;
            }
            if(Vector3.Distance(newTargetPos, targetPosition) > 0.05f){
                targetPosition = newTargetPos;
            }
            var step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        }
    }
}
