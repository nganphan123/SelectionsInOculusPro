using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class VemInteractable : MonoBehaviour
{
    [field: SerializeField]
    public bool IsHovered { get; private set; }

    [SerializeField]
    public GameObject cursor;

    private Vector3 leftHit;
    private Vector3 rightHit;
    
    // Start is called before the first frame update
    void Start()
    {
        cursor.SetActive(false);
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
        cursor.SetActive(IsHovered);
        Debug.Log("cursor active" + cursor.active);
        Debug.Log("is vem hovered " + IsHovered);
        if(IsHovered && cursor != null){
            cursor.transform.position = Vector3.Lerp(leftHit, rightHit, 0.5f);
        }
    }
}
