using System.Transactions;
using UnityEngine;

public class Visual : MonoBehaviour
{
    [SerializeField]
    private EyeTrackingRay _rayInteractor;

    [SerializeField]
    private Material _hoverColor = default;

    [SerializeField]
    private Material _stillColor = default;

    private Vector3 defaultPos = new Vector3(0, 0, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = _stillColor;
    }

    // void Update()
    // {
    //     if (_rayInteractor.state == EyeTrackingRay.State.STILL)
    //     {
    //         gameObject.GetComponent<MeshRenderer>().material = _stillColor;
    //         transform.position = new Vector3(transform.position.x, transform.position.y, transform.InverseTransformDirection(defaultPos).z);
    //     }
    // }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (_rayInteractor.state == EyeTrackingRay.State.HOVERED || _rayInteractor.state == EyeTrackingRay.State.SELECT)
        {
            gameObject.GetComponent<MeshRenderer>().material = _hoverColor;
            // transform.position = new Vector3(transform.position.x, transform.position.y, transform.InverseTransformDirection(_rayInteractor.End).z);
            transform.position = transform.InverseTransformDirection(_rayInteractor.End);
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = _stillColor;
            var toLocalSpace = transform.InverseTransformDirection(defaultPos);
            // transform.position = new Vector3(transform.position.x, transform.position.y, toLocalSpace.z);
            transform.position = toLocalSpace;
        }
    }
}
