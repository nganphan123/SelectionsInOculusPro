using UnityEngine;

public class InteractableControl : MonoBehaviour
{
    [SerializeField]
    private float speed;

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
                speed = 0.005f;
                break;
            case 1:
                speed = 0.01f;
                break;
            case 2:
                speed = 0.015f;
                break;
        }
        reverse = false;
        rightBound = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        leftBound = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (!motionActive) return;
        if (!reverse)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightBound, speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, leftBound, speed);
        }
        if (transform.position == leftBound || transform.position == rightBound)
        {
            reverse = !reverse;
        }
    }
}
