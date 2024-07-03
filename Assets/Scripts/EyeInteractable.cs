using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class EyeInteractable : MonoBehaviour
{
    [field: SerializeField]
    public bool IsHovered { get; private set; }

    [field: SerializeField]
    public bool IsSelected { get; private set; }

    [field: SerializeField]
    public bool IsInGaze { get; private set; }

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
    [SerializeField]
    private RoundController roundController;

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
        float oneDimSize = OptionsController.sizeMap[sizeOpt];
        Vector3 newSize = new Vector3(oneDimSize, 0.01f, oneDimSize);
        // change cube size
        transform.localScale = newSize;
        SetGaze(false);
    }

    public void Hover(bool state)
    {
        IsHovered = state;
    }

    public void SetGaze(bool state)
    {
        IsInGaze = state;
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
        // set target color
        if (gameObject == roundController.targetCube)
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
            // instance of time the object was hovered, before selected
            roundController.lastHoverTime = DateTime.Now;
            // statusText.text = $"<color=\"yellow\">HOVERED</color>";
        }
        if (IsSelected)
        {
            if (gameObject == roundController.targetCube)
            {
                roundController.endTime = DateTime.Now;
                OnObjectSelect?.Invoke(gameObject);
            }
            meshRenderer.material = OnSelectActiveMaterial;
            // statusText.text = $"<color=\"yellow\">SELECTED</color>";
        }
        if (!IsHovered && !IsSelected && !IsTarget)
        {
            meshRenderer.material = OnIdleMaterial;
            // statusText.text = $"<color=\"yellow\">IDLE</color>";
        }
        if (IsInGaze)
        {
            gameObject.GetComponent<InteractableControl>().SetSlow(true);
        }
        else
        {
            gameObject.GetComponent<InteractableControl>().SetSlow(false);
        }
    }
}
