using UnityEngine;

public class TiltControls : MonoBehaviour
{
    void Start()
    {
        //checks gyro support
        GyroManager.Instance.EnableGyro();
        Screen.orientation = ScreenOrientation.Portrait;
    }
    
    void Update()
    {
        //get world input
        Quaternion worldRotation = GyroManager.Instance.GetGyroRotation();
        
        // make the rotation relative to the local rotation rather than the world
        Quaternion localRotation = GyroManager.Instance.GetGyroReferenceRotation() * worldRotation;
        
        //convert to euler
        Vector3 euler = localRotation.eulerAngles; 
 
        //zrotation
        Quaternion zRotation = Quaternion.AngleAxis(euler.z, Vector3.forward );
 
        // reverse the rotation about the z-axis
        localRotation = Quaternion.Inverse( zRotation ) * localRotation;
 
        // rotate about the x axis to make the y axis point the right direction
        localRotation = Quaternion.AngleAxis(90, Vector3.right ) * localRotation;

        localRotation = new Quaternion(-localRotation.x, 0.0f, localRotation.z, localRotation.w);
      
        //debugging
        Vector3 up = localRotation * Vector3.up;
        Vector3 right = localRotation * Vector3.right;
        Vector3 fwd = localRotation * Vector3.forward;
 
        Debug.DrawRay( transform.position, up * 100, Color.green );
        Debug.DrawRay( transform.position, right * 100, Color.red );
        Debug.DrawRay( transform.position, fwd * 100, Color.blue );
 
        transform.rotation = localRotation; 
    }
}
