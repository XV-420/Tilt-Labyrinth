using UnityEngine;

public class TiltControls : MonoBehaviour
{
    [SerializeField] float MaxValue = 315; //-45
    [SerializeField] float MinValue = 45;//45
    void Start()
    {
        //checks gyro support
        GyroManager.Instance.EnableGyro();
        GyroManager.Instance.GetGyroReferenceRotation();
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
        localRotation.x = Mathf.Clamp(localRotation.x, Mathf.Sin(Mathf.Deg2Rad * -45f), Mathf.Sin(Mathf.Deg2Rad * 45f));
        localRotation.y = Mathf.Clamp(localRotation.y, Mathf.Sin(Mathf.Deg2Rad * -45f), Mathf.Sin(Mathf.Deg2Rad * 45f));
        
        localRotation = new Quaternion(localRotation.x, -localRotation.z, localRotation.y, -localRotation.w);
        transform.localRotation = localRotation; 
        
        
        
        
        //debugging
        Vector3 up = localRotation * Vector3.up;
        Vector3 right = localRotation * Vector3.right;
        Vector3 fwd = localRotation * Vector3.forward;
      

        Debug.DrawRay( transform.position, up * 100, Color.green );
        Debug.DrawRay( transform.position, right * 100, Color.red );
        Debug.DrawRay( transform.position, fwd * 100, Color.blue );
       
        //angles 
        transform.eulerAngles = new Vector3(ClampAngle(transform.eulerAngles.x), transform.eulerAngles.y, ClampAngle(transform.eulerAngles.z));
     

        // Calculate a rotation a step closer to the target and applies rotation to this object
       


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
