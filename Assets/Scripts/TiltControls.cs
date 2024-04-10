using System.IO.Compression;
using UnityEngine;

public class TiltControls : MonoBehaviour
{

    enum ControlType
    {
        tilt,
        swipe
    }

    ControlType controlType = ControlType.swipe;
    //get mouse held
    bool isMouseHeld = false;
    //the starting and ending positions of a swipe
    Vector3 startingSwipe;
    Vector3 endingSwipe;

    private Rigidbody rigidbody;
    
    void Update()
    {
        if (controlType == ControlType.tilt)
        {
            Vector3 fixedTilt = Input.acceleration;
            fixedTilt = tiltReference * fixedTilt;



            fixedTilt.z = fixedTilt.y;
            fixedTilt.y = 0.0f;

            rigidbody.AddForce(fixedTilt * 200.0f * Time.deltaTime);
        }
        //Swipe controls
        else
        {
            
            //get if mouse is held
            if (isMouseHeld)
            {
                //if the mouse was held in the last frame, but no longer is now, record the ending position
                if (Input.GetMouseButtonUp(0))
                {
                    endingSwipe = Input.mousePosition;
                    isMouseHeld = false;
                }
            }
            else
            {
                //if the mouse wasn't held in the, but is now, record the starting position
                if (Input.GetMouseButtonDown(0))
                {
                    startingSwipe = Input.mousePosition;
                    isMouseHeld = true;
                }
            }

            if (isMouseHeld)
            {
                Vector3 mousePos = startingSwipe - endingSwipe;

                //figure out if the swipe is in a positive or negative direction in both x and y


                /*//translate the mouse positions into the angle the board should rotate by.
                //TODO: probably make this a function for cleaner code.
                //TODO: find the actual number that's the exact center. 430 is just an approximation.
                //subtract the center pos from the mouse position to make the center = 0
                float xAngle = mousePos.x - 430;
                //if the angle is outside how far we want them to be able to tilt, simply don't
                if (xAngle > 45)
                {
                    xAngle = 45;
                }
                if (xAngle < -45)
                {
                    xAngle = -45;
                }
                //TODO: find the actual number that's the exact center. 220 is just an approximation.
                //subtract the center pos from the mouse position to make the center = 0
                float yAngle = mousePos.y - 220;
                //if the angle is outside how far we want them to be able to tilt, simply don't
                if (yAngle > 45)
                {
                    yAngle = 45;
                }
                if (yAngle < -45)
                {
                    yAngle = -45;
                }*/

                Vector3 fixedTilt = mousePos;

                fixedTilt.z = fixedTilt.y;
                fixedTilt.y = 0.0f;

                rigidbody.AddForce(fixedTilt * 200.0f * Time.deltaTime);
            }
        }
    }
    
    private Quaternion tiltReference;
    
    public void CalibrateAccelerometer()
    {
        Vector3 accelerationReference = Input.acceleration;
 
        Quaternion rotateQuaternion = Quaternion.FromToRotation(
            new Vector3(0.0f, 0.0f, -1.0f), accelerationReference);
 
        tiltReference = Quaternion.Inverse(rotateQuaternion);
    }
   
    void Start()
    {
        CalibrateAccelerometer();
        rigidbody = GetComponent<Rigidbody>();
    }

}



