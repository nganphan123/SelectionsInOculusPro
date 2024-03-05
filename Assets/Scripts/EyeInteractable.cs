using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class EyeInteractable : MonoBehaviour
{
    [field: SerializeField]
    public bool IsHovered { get; private set; }

    [field: SerializeField]
    public bool IsSelected { get; private set; }

    [SerializeField]
    private UnityEvent<GameObject> OnObjectHover;

    [SerializeField]
    private UnityEvent<GameObject> OnObjectSelect;

    [SerializeField]
    private Material OnHoverActiveMaterial;

    [SerializeField]
    private Material OnSelectActiveMaterial;

    [SerializeField]
    private Material OnIdleMaterial;

    [SerializeField]
    private Material TargetMaterial;

    private Transform originalAnchor;

    // private TextMeshPro statusText;

    public MeshRenderer meshRenderer;

    private bool IsTarget;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        // statusText = GetComponentInChildren<TextMeshPro>();
        originalAnchor = transform.parent;
        int sizeOpt = PlayerPrefs.GetInt("size");
        Vector3 newSize;
        switch (sizeOpt)
        {
            case 0:
                newSize = new Vector3(0.1f, 0.1f, 0.1f);
                break;
            case 1:
                newSize = new Vector3(0.2f, 0.2f, 0.2f);
                break;
            default:
                newSize = new Vector3(0.3f, 0.3f, 0.3f);
                break;

        }
        // change cube size
        transform.localScale = newSize;
    }

    public void Hover(bool state)
    {
        IsHovered = state;
    }

    public void Select(bool state, Transform anchor = null)
    {
        IsSelected = state;
        if (anchor) transform.SetParent(anchor);
        if (!IsSelected) transform.SetParent(originalAnchor);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("equals" + (gameObject == RandomCubeController.targetCube));
        // set target color
        if (gameObject == RandomCubeController.targetCube)
        {
            meshRenderer.material = TargetMaterial;
            IsTarget = true;
        }
        else
        {
            IsTarget = false;
        }
        if (IsHovered)
        {
            meshRenderer.material = OnHoverActiveMaterial;
            OnObjectHover?.Invoke(gameObject);
            // statusText.text = $"<color=\"yellow\">HOVERED</color>";
        }
        if (IsSelected)
        {
            // Timer.endTime = DateTime.Now;
            // SceneManager.LoadScene("StartMenu");
            meshRenderer.material = OnSelectActiveMaterial;
            if (ReferenceEquals(gameObject, RandomCubeController.targetCube))
            {
                OnObjectSelect?.Invoke(gameObject);
            }
            // statusText.text = $"<color=\"yellow\">SELECTED</color>";
        }
        if (!IsHovered && !IsSelected && !IsTarget)
        {
            meshRenderer.material = OnIdleMaterial;
            // statusText.text = $"<color=\"yellow\">IDLE</color>";
        }
    }
}
