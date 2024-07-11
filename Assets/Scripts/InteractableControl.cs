using BezierSolution;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class InteractableControl : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float slowSpeed;
    public bool isSlow;
    public bool motionActive = true;
    private BezierWalkerWithSpeed bezierControl;
    private float offset = 0.1f;
    private int vemOption;

    // Start is called before the first frame update
    void Start()
    {
        vemOption = PlayerPrefs.GetInt("vemType");
        vemOption = 3;
        bezierControl = transform.GetComponent<BezierWalkerWithSpeed>();
        BezierSpline spline = createBezierLine();
        bezierControl.spline = spline;
        int preferredSpeed = PlayerPrefs.GetInt("speed");
        speed = OptionsController.speedMap[preferredSpeed];
        // when object is in gaze range, slow down speed
        slowSpeed = speed * 0.4f; // decrease speed by 75%
    }

    int getVemSize(int vemOption){
        switch(vemOption){
            case 0: return 2;
            case 1: return 4;
            case 2: return 6;
            default: return 6; //flat vem
        }
    }

    float getVemYCenter(int vemOption){
        switch(vemOption){
            case 0: return 2.65f;
            case 1: return 0.6f;
            case 2: return -1.4f;
            default: return 0; //flat vem
        }
    }

    BezierSpline createBezierLine(){
        if (vemOption == 3){
            return createStraightBezlier(getVemSize(vemOption), getVemYCenter(vemOption));
        }else{
            return createArchBezierLine(getVemSize(vemOption), getVemYCenter(vemOption));
        }
    }

    BezierSpline createStraightBezlier(int vemWidth, float xCenter){
        const int vemDistance = 3;
        BezierSpline spline = new GameObject().AddComponent<BezierSpline>();
        spline.Initialize(2);
        float y = transform.TransformPoint(transform.position).y;
        float worldXCenter = transform.TransformPoint(new Vector3(xCenter,0,0)).x;
        spline[0].position = new Vector3(worldXCenter - vemWidth/2 + offset, y, vemDistance-0.01f);
        spline[0].normal = new Vector3(0,0,1);
        spline[1].position = new Vector3(worldXCenter + vemWidth/2 - offset, y, vemDistance-0.01f);
        spline[1].normal = new Vector3(0,0,1);
        return spline;
    }

    BezierSpline createArchBezierLine(int vemSize, float yCenter){
        float fixedZ = yCenter + 0.2f; //0.5f
        // start and end points of the arc ([x1, y1] and [x4, y4], respectively) 
        float x1= -vemSize + 0.61f + offset;
        float z1 = fixedZ;
        float x4 = vemSize - 0.61f - offset;
        float z4 = fixedZ;

        // center of the circle ([xc, yc])
        float xc = 0, zc = yCenter; //0.3
        
        float ax = x1 - xc;
        float az = z1 - zc;
        float bx = x4 - xc;
        float bz = z4 - zc;
        float q1 = ax * ax + az * az;
        float q2 = q1 + ax * bx + az * bz;
        double k2 = 4/3.0f * (Math.Sqrt(2 * q1 * q2) - q2) / (ax * bz - az * bx);

        // control points for a cubic Bézier curve ([x2, y2] and [x3, y3])
        float x2 = (float)(xc + ax - k2 * az);
        float z2 = (float)(zc + az + k2 * ax);
        float x3 = (float)(xc + bx + k2 * bz);
        float z3 = (float)(zc + bz - k2 * bx);

        BezierSpline spline = new GameObject().AddComponent<BezierSpline>();
        spline.Initialize( 2 );

        float y = transform.TransformPoint(transform.position).y;

        // Set first end point's (world) position to 2,3,5
        spline[0].position = new Vector3( x1, y, z1 );
        spline[1].position = new Vector3( x4, y, z4 );

        // Set handle mode of first end point to Free to independently adjust each control point
        spline[0].handleMode = BezierPoint.HandleMode.Mirrored;

        // Reposition the control points of the first end point
        spline[0].precedingControlPointPosition = new Vector3( -x2 +2*x1, y, -z2 + 2*z1 );
        spline[1].precedingControlPointPosition = new Vector3( x3, y, z3);
        spline.autoCalculateNormals = true;
        return spline;
    }

    public void SetSlow(bool state)
    {
        isSlow = state;
    }

    // Update is called once per frame
    void Update()
    {
        if (!motionActive){
            bezierControl.speed = 0;
        }
        float currentSpeed;
        if(isSlow){
            currentSpeed = slowSpeed;
        }
        else{
            currentSpeed=speed;
        }
        if(currentSpeed != bezierControl.speed){
            bezierControl.speed = currentSpeed;
        }
    }
}
