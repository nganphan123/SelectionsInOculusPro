using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class CursorController : MonoBehaviour
{
    [field: SerializeField]
    public bool IsHovered { get; private set; }

    private Vector3 leftHit;
    private Vector3 rightHit;
    private Renderer renderer;
    
    // Start is called before the first frame update
    void Start()
    {
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
    void FixedUpdate()
    {
        renderer.enabled = IsHovered;
        if(IsHovered){
            transform.position = Vector3.Lerp(leftHit, rightHit, 0.5f);
        }
    }
}
