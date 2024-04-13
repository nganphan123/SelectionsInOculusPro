using UnityEngine;

public class InteractableControl : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float slowSpeed;
    public bool isSlow;

    private Vector3 rightBound;
    private Vector3 leftBound;
    bool reverse;
    public bool motionActive = true;

    // Start is called before the first frame update
    void Start()
    {
        int preferredSpeed = PlayerPrefs.GetInt("speed");
        switch (preferredSpeed)
        {
            case 0:
                speed = 0.01f;
                break;
            case 1:
                speed = 0.02f;
                break;
            case 2:
                speed = 0.03f;
                break;
        }
        // when object is in gaze range, slow down speed
        slowSpeed = speed * 0.25f; // decrease speed by 75%
        reverse = false;
        rightBound = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        leftBound = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
    }

    public void SetSlow(bool state)
    {
        isSlow = state;
    }

    // Update is called once per frame
    void Update()
    {
        if (!motionActive) return;
        float currentSpeed;
        if (isSlow)
        {
            currentSpeed = slowSpeed;
        }
        else
        {
            currentSpeed = speed;
        }
        if (!reverse)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightBound, currentSpeed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, leftBound, currentSpeed);
        }
        if (transform.position == leftBound || transform.position == rightBound)
        {
            reverse = !reverse;
        }
    }
}
