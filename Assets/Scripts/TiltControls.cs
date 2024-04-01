using System.IO.Compression;
using UnityEngine;

public class TiltControls : MonoBehaviour
{
    [SerializeField] float MaxValue = 315; //-45
    [SerializeField] float MinValue = 45;//45
    void Start()
    {
        //checks gyro support
        GyroManager.Instance.EnableGyro();
    }
    
    void Update()
    {
        //get world input
        Quaternion worldRotation = GyroManager.Instance.GetGyroRotation();
        
        // make the rotation relative to the local rotation rather than the world
        Quaternion localRotation = GyroManager.Instance.GetGyroReferenceRotation() * worldRotation;
        
        Vector3 euler = localRotation.eulerAngles;


        
        Quaternion zRotation = Quaternion.AngleAxis(euler.z, Vector3.forward);
        
        zRotation = new Quaternion(zRotation.x, zRotation.y, zRotation.z, 0.0f);
        // reverse the rotation about the z-axis
        localRotation = Quaternion.Inverse( zRotation ) * localRotation;

        localRotation = new Quaternion(localRotation.x, localRotation.z, localRotation.y, -localRotation.w);

        Vector3 localRotationEuler = localRotation.eulerAngles;
        
        //make y the same always
        localRotationEuler.y = -localRotationEuler.normalized.y;

        
        //reverse z by the x so its rotation doesn't change when x is clamped FIX
        if (localRotationEuler.x > MinValue && localRotationEuler.x < MaxValue)
        {
            Quaternion xRotation = Quaternion.AngleAxis(localRotationEuler.x, Vector3.right);
            // reverse the rotation about the x-axis
            localRotation = (Quaternion.Inverse(xRotation) * localRotation);

            if (localRotationEuler.z - localRotation.eulerAngles.z > MinValue)
            {
               // if (localRotationEuler.z > 90)
                   // localRotationEuler.z = 0.0f;
                if (localRotationEuler.z < 270)
                    localRotationEuler.z = 270.0f;
            }
        }

        
        
        //clamp and rotate
        localRotationEuler = new Vector3(ClampAngle(localRotationEuler.x), localRotationEuler.y, ClampAngle(localRotationEuler.z));
        transform.localRotation = Quaternion.Euler(localRotationEuler);
      
       
        //debugging
        Vector3 up = localRotation * Vector3.up;
        Vector3 right = localRotation * Vector3.right;
        Vector3 fwd = localRotation * Vector3.forward;
      

        Debug.DrawRay( transform.position, up * 100, Color.green );
        Debug.DrawRay( transform.position, right * 100, Color.red );
        Debug.DrawRay( transform.position, fwd * 100, Color.blue );

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
    private float ConvertToPositiveAngle(float angle)
    {
        while(angle < 0) { 
            angle += 360.0f;
        }

        return angle;
    }
}
