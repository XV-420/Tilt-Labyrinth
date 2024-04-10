using System.IO.Compression;
using UnityEngine;

public class TiltControls : MonoBehaviour
{

    private Rigidbody rigidbody;
    
    void Update()
    {
        
        Vector3 fixedTilt = Input.acceleration;
        fixedTilt = tiltReference * fixedTilt;
 


        fixedTilt.z = fixedTilt.y;
        fixedTilt.y = 0.0f;

        //rigidbody.AddForce(fixedTilt * 200.0f * Time.deltaTime);
        rigidbody.AddForce(fixedTilt * 200.0f * Time.deltaTime);
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



