using UnityEngine;

public class TiltControls : MonoBehaviour
    
    { 
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
        localRotation = Quaternion.Inverse(zRotation) * localRotation;

        localRotation = new Quaternion(localRotation.x, -localRotation.z, localRotation.y, localRotation.w);
        transform.localRotation = localRotation;



        //debugging
        Vector3 up = localRotation * Vector3.up;
        Vector3 right = localRotation * Vector3.right;
        Vector3 fwd = localRotation * Vector3.forward;

        Debug.DrawRay(transform.position, up * 100, Color.green);
        Debug.DrawRay(transform.position, right * 100, Color.red);
        Debug.DrawRay(transform.position, fwd * 100, Color.blue);
    }
    }
