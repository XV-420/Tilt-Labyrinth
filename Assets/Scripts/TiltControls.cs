using UnityEngine;

public class TiltControls : MonoBehaviour
{
    [SerializeField] float MaxValue = 315; //-45
    [SerializeField] float MinValue = 45;//45
    enum ControlType
    {
        tilt,
        swipe
    }

    ControlType controlType = ControlType.swipe;
    //get mouse held
    bool isMouseHeld = false;

    void Start()
    {
        //checks gyro support
        GyroManager.Instance.EnableGyro();
        GyroManager.Instance.GetGyroReferenceRotation();
    }
    
    void Update()
    {

        if (controlType == ControlType.tilt) {
            //get world input
            Quaternion worldRotation = GyroManager.Instance.GetGyroRotation();

            // make the rotation relative to the local rotation rather than the world
            Quaternion localRotation = GyroManager.Instance.GetGyroReferenceRotation() * worldRotation;

            Vector3 euler = localRotation.eulerAngles;



            Quaternion zRotation = Quaternion.AngleAxis(euler.z, Vector3.forward);

            zRotation = new Quaternion(zRotation.x, zRotation.y, zRotation.z, 0.0f);
            // reverse the rotation about the z-axis
            localRotation = Quaternion.Inverse(zRotation) * localRotation;
            localRotation.x = Mathf.Clamp(localRotation.x, Mathf.Sin(Mathf.Deg2Rad * -45f), Mathf.Sin(Mathf.Deg2Rad * 45f));
            localRotation.y = Mathf.Clamp(localRotation.y, Mathf.Sin(Mathf.Deg2Rad * -45f), Mathf.Sin(Mathf.Deg2Rad * 45f));

            localRotation = new Quaternion(localRotation.x, -localRotation.z, localRotation.y, -localRotation.w);
            transform.localRotation = localRotation;




            //debugging
            Vector3 up = localRotation * Vector3.up;
            Vector3 right = localRotation * Vector3.right;
            Vector3 fwd = localRotation * Vector3.forward;


            Debug.DrawRay(transform.position, up * 100, Color.green);
            Debug.DrawRay(transform.position, right * 100, Color.red);
            Debug.DrawRay(transform.position, fwd * 100, Color.blue);

            //angles 
            transform.eulerAngles = new Vector3(ClampAngle(transform.eulerAngles.x), transform.eulerAngles.y, ClampAngle(transform.eulerAngles.z));


            // Calculate a rotation a step closer to the target and applies rotation to this object


        }
        else
        {
            //get if mouse is held
            if (isMouseHeld)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    isMouseHeld = false;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    isMouseHeld = true;
                }
            }
           
            //get world input
            Quaternion worldRotation = GyroManager.Instance.GetGyroRotation();

            // make the rotation relative to the local rotation rather than the world
            Quaternion localRotation = GyroManager.Instance.GetGyroReferenceRotation() * worldRotation;

            Vector3 euler = localRotation.eulerAngles;



            Quaternion zRotation = Quaternion.AngleAxis(euler.z, Vector3.forward);

            if (isMouseHeld) {
                Vector3 mousePos = Input.mousePosition;
                {
                    
                }
                //translate the mouse positions into the angle the board should rotate by.
                //TODO: probably make this a function for cleaner code.
                //TODO: find the actual number that's the exact center. 430 is just an approximation.
                //subtract the center pos from the mouse position to make the center = 0
                float xAngle = mousePos.x - 430;
                //if the angle is outside how far we want them to be able to tilt, simply don't
                if(xAngle > 45)
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
                }
                Debug.Log(yAngle + " " + mousePos.y);

                zRotation = new Quaternion(zRotation.x, zRotation.y, zRotation.z, 0.0f);
                
                // reverse the rotation about the z-axis
                localRotation = Quaternion.Inverse(zRotation) * localRotation;
                localRotation.x = Mathf.Clamp(localRotation.x, Mathf.Sin(Mathf.Deg2Rad * -45f), Mathf.Sin(Mathf.Deg2Rad * 45f));
                localRotation.y = Mathf.Clamp(localRotation.y, Mathf.Sin(Mathf.Deg2Rad * -45f), Mathf.Sin(Mathf.Deg2Rad * 45f));

                localRotation = new Quaternion(localRotation.x, -localRotation.z, localRotation.y, -localRotation.w);
                transform.localRotation = localRotation;


                //angles 
                //use the opposite of xAngle to feel natural
                //TODO: Idea for a stretch goal: give opption to inverse controls?
                transform.eulerAngles = new Vector3(yAngle, transform.eulerAngles.y, -xAngle);

            }
            else
            {
                zRotation = new Quaternion(zRotation.x, zRotation.y, zRotation.z, 0.0f);
                // reverse the rotation about the z-axis
                localRotation = Quaternion.Inverse(zRotation) * localRotation;
                localRotation.x = Mathf.Clamp(localRotation.x, Mathf.Sin(Mathf.Deg2Rad * -45f), Mathf.Sin(Mathf.Deg2Rad * 45f));
                localRotation.y = Mathf.Clamp(localRotation.y, Mathf.Sin(Mathf.Deg2Rad * -45f), Mathf.Sin(Mathf.Deg2Rad * 45f));

                localRotation = new Quaternion(localRotation.x, -localRotation.z, localRotation.y, -localRotation.w);
                transform.localRotation = localRotation;

                //angles 
                transform.eulerAngles = new Vector3(ClampAngle(transform.eulerAngles.x), transform.eulerAngles.y, ClampAngle(transform.eulerAngles.z));

            }

            //debugging
            Vector3 up = localRotation * Vector3.up;
            Vector3 right = localRotation * Vector3.right;
            Vector3 fwd = localRotation * Vector3.forward;


            Debug.DrawRay(transform.position, up * 100, Color.green);
            Debug.DrawRay(transform.position, right * 100, Color.red);
            Debug.DrawRay(transform.position, fwd * 100, Color.blue);


            // Calculate a rotation a step closer to the target and applies rotation to this object


        }


    }
    private float ClampAngle(float angle)
    {
        if (angle >MinValue && angle < MaxValue)
        {       // if angle in the critic region...
            if (angle < MaxValue && angle> 180)
            {
                angle = MaxValue;
            }
            else
            {
                angle = MinValue;
            }
        }
        // if angle negative, convert to 0..360
        return angle;
            }
}
