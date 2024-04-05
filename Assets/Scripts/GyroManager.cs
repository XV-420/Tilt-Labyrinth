using UnityEngine;

//singleton
public class GyroManager : MonoBehaviour
{
    #region Instance

    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if(instance == null)
                {
                    instance = new GameObject("Spawned GyroManager", typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion

    private Gyroscope gyro;
    private Vector3 rotation;
    private bool gyroEnabled;
    private Vector3 referenceRotation;

    // Update is called once per frame
    void Update()
    {
        //sets rotation based on gyro
        if (gyroEnabled) rotation = gyro.userAcceleration;
    }

    //starts the gyro if supported by the device, returns if already active
    public void EnableGyro()
    {
        if (gyroEnabled) return;
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroEnabled = true;
            referenceRotation = -gyro.userAcceleration;
        }
        else gyroEnabled = false;
    }

    //returns the rotation
    public Vector3 GetGyroRotation()
    {
        return rotation;
    }
    
    public Vector3 GetGyroReferenceRotation()
    {
        return referenceRotation;
    }
    
    public void SetGyroReferenceRotation()
    {
       referenceRotation = -gyro.userAcceleration;
    }
}
