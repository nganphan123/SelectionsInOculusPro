using System.Collections.Generic;
using UnityEngine;

public class EyeGazeRange : MonoBehaviour
{
    [SerializeField]
    private LayerMask layersToInclude;
    [SerializeField]
    private float maxDistance = 10;
    [SerializeField]
    private float rangeRadius;
    [SerializeField]
    private GameObject rangeBubble;
    private List<EyeInteractable> lastEyeInteractables = new List<EyeInteractable>();
    private Dictionary<int, EyeInteractable> interactables = new Dictionary<int, EyeInteractable>();

    private void Start()
    {
        rangeBubble.SetActive(true);
    }

    private void OnGazeEnded()
    {
        foreach (EyeInteractable i in lastEyeInteractables)
        {
            i.SetGaze(false);
        }
        lastEyeInteractables.Clear();
    }

    void Update()
    {
        OnGazeEnded();
        Vector3 castDirection = transform.TransformDirection(Vector3.forward);
        RaycastHit[] colliders = Physics.SphereCastAll(transform.position, rangeRadius, castDirection, maxDistance, layersToInclude);
        if (colliders.Length == 0)
        {
            return;
        }
        foreach (RaycastHit collider in colliders)
        {
            if (!interactables.TryGetValue(collider.transform.gameObject.GetHashCode(), out EyeInteractable eyeInteractable))
            {
                eyeInteractable = collider.transform.GetComponent<EyeInteractable>();
                interactables.Add(collider.transform.gameObject.GetHashCode(), eyeInteractable);
            }
            lastEyeInteractables.Add(eyeInteractable);
            eyeInteractable.SetGaze(true);
        }
    }
}
