using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EyeTrackingRay : MonoBehaviour
{
    // for eye tracking, the script is added to both eye, this boolean assign only one eye to keep track of trial count
    [SerializeField]
    private bool isLeftEye;
    [SerializeField]
    private float rayDistance = 1.0f;

    [SerializeField]
    private float rayWidth = 0.01f;

    [SerializeField]
    private LayerMask layersToInclude;

    [SerializeField]
    private Color rayColorDefaultState = Color.yellow;

    [SerializeField]
    private Color rayColorHoverState = Color.red;

    [SerializeField]
    private OVRHand handUsedForPinchSelection;

    [SerializeField]
    private bool rayDisplay;

    [SerializeField]
    private bool mockHandUsedForPinchSelection;

    [SerializeField]
    public OVRFaceExpressions faceExp;
    [SerializeField]
    private RoundController roundController;

    private bool intercepting;

    private bool allowPinchSelection;

    private LineRenderer lineRenderer;

    private Dictionary<int, EyeInteractable> interactables = new Dictionary<int, EyeInteractable>();

    private EyeInteractable lastEyeInteractable;

    public Vector3 End;

    Func<bool> selectObj;

    public enum State
    {
        SELECT,
        STILL,
    }
    public State state = State.STILL;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        allowPinchSelection = handUsedForPinchSelection != null;
        int selection = PlayerPrefs.GetInt("selection");
        switch (selection)
        {
            case 0:
                selectObj = IsPinching;
                break;
            default:
                selectObj = IsRightEyeClose;
                break;
        }
        SetupRay();
    }

    void SetupRay()
    {
        lineRenderer.useWorldSpace = false;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = rayWidth;
        lineRenderer.endWidth = rayWidth;
        lineRenderer.startColor = rayColorDefaultState;
        lineRenderer.endColor = rayColorDefaultState;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, transform.position.z + rayDistance));
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.enabled = !selectObj() && rayDisplay;

        SelectionStarted();

        // clear all hover states
        if (!intercepting)
        {
            lineRenderer.startColor = lineRenderer.endColor = rayColorDefaultState;
            lineRenderer.SetPosition(1, new Vector3(0, 0, transform.position.z + rayDistance));
            OnHoverEnded();
        }
    }

    void FixedUpdate()
    {
        if (selectObj()) return;

        Vector3 rayDirection = transform.TransformDirection(Vector3.forward) * rayDistance;

        intercepting = Physics.Raycast(transform.position, rayDirection, out RaycastHit hit, Mathf.Infinity, layersToInclude);

        if (intercepting)
        {
            OnHoverEnded();
            lineRenderer.startColor = lineRenderer.endColor = rayColorHoverState;
            // keep cache of eye interactables
            if (!interactables.TryGetValue(hit.transform.gameObject.GetHashCode(), out EyeInteractable eyeInteractable))
            {
                eyeInteractable = hit.transform.GetComponent<EyeInteractable>();
                interactables.Add(hit.transform.gameObject.GetHashCode(), eyeInteractable);
            }

            var toLocalSpace = transform.InverseTransformPoint(eyeInteractable.transform.position);
            lineRenderer.SetPosition(1, new Vector3(0, 0, toLocalSpace.z));

            eyeInteractable.Hover(true);

            // Modify cursor if object is hit
            End = hit.point;

            lastEyeInteractable = eyeInteractable;
        }
    }

    private void SelectionStarted()
    {
        // var motionControl = lastEyeInteractable.GetComponent<InteractableControl>();
        if (selectObj())
        {
            // lastEyeInteractable?.Select(true, (handUsedForPinchSelection?.IsTracked ?? false) ? handUsedForPinchSelection.transform : transform);
            lastEyeInteractable?.Select(true);
            // if (motionControl.enabled) motionControl.motionActive = false;
            if (isLeftEye && state == State.STILL)
            {
                // first time making selection in the frame
                roundController.totalAttemptsMade += 1;
            }
            state = State.SELECT;
        }
        else
        {
            lastEyeInteractable?.Select(false);
            // if (motionControl.enabled) motionControl.motionActive = true;
            state = State.STILL;
        }
    }

    private void OnHoverEnded()
    {
        // foreach (var interactable in interactables) interactable.Value.Hover(false);
        lastEyeInteractable?.Hover(false);
        lastEyeInteractable = null;
        // state = State.STILL;
    }

    private void OnDestroy() => interactables.Clear();

    private bool IsPinching() => (allowPinchSelection && handUsedForPinchSelection.GetFingerIsPinching(OVRHand.HandFinger.Index)) || mockHandUsedForPinchSelection;

    private bool IsRightEyeClose() => Math.Round(faceExp[OVRFaceExpressions.FaceExpression.EyesClosedR]) >= 1.0 && faceExp[OVRFaceExpressions.FaceExpression.EyesClosedL] < 1.0;
}
