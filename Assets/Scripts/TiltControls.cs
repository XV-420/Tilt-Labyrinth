using System.IO.Compression;
using UnityEngine;

public class TiltControls : MonoBehaviour
{
    [SerializeField] float MaxValue = 315; //-45
    [SerializeField] float MinValue = 45;//45

    private Rigidbody rigidbody;
    void Start()
    {
        //checks gyro support
        GyroManager.Instance.EnableGyro();
        
        rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        //get world input
        Quaternion worldRotation = GyroManager.Instance.GetGyroRotation();
        
        // make the rotation relative to the local rotation rather than the world
        


        
        Quaternion zRotation = Quaternion.AngleAxis(euler.z, Vector3.forward);
        
        zRotation = new Quaternion(zRotation.x, zRotation.y, zRotation.z, 0.0f);
        // reverse the rotation about the z-axis


        
        //reverse z by the x so its rotation doesn't change when x is clamped FIX
        if (localRotationEuler.x > MinValue && localRotationEuler.x < MaxValue)
        {
            Quaternion xRotation = Quaternion.AngleAxis(localRotationEuler.x, Vector3.right);
            // reverse the rotation about the x-axis

        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.AddTorque(Vector3.Scale( EulerAnglesToDirection(localRotationEuler), Vector3.up), ForceMode.Impulse);

        Debug.DrawRay( transform.position, EulerAnglesToDirection(localRotationEuler) * 10000, Color.yellow );
        //debugging
        Vector3 up = worldRotation * Vector3.up;
        Vector3 right = worldRotation * Vector3.right;
        Vector3 fwd = worldRotation * Vector3.forward;
      

       // Debug.DrawRay( transform.position, up * 100, Color.green );
       // Debug.DrawRay( transform.position, right * 100, Color.red );
       // Debug.DrawRay( transform.position, fwd * 100, Color.blue );

    }
   
    // eulerAngles in radians
    Vector3 EulerAnglesToDirection(Vector3 eulerAngles) {
        float sinYaw = Mathf.Sin(eulerAngles.y);
        float cosYaw = Mathf.Cos(eulerAngles.y);
 
        float sinPitch = Mathf.Sin(eulerAngles.x);
        float cosPitch = Mathf.Cos(eulerAngles.x);
        cosPitch *= -1.0f;
 
        Vector3 rotatedDirection = new Vector3(
            sinYaw * cosPitch,
            sinPitch,
            cosYaw * cosPitch
        );
 
    }

}
