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
    private Quaternion rotation;
    private bool gyroEnabled;
    private Quaternion referenceRotation;
    private Vector3 simulatedRotation;

    // Update is called once per frame
    void Update()
    {
        //sets rotation based on gyro
        if (gyroEnabled) rotation = gyro.attitude;
        float rotationSpeed = 100f;
        
       

        // Apply sensitivity
        simulatedRotation *= 1;

        // Apply simulated rotation to the GameObject
        transform.rotation = Quaternion.Euler(simulatedRotation);
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
            referenceRotation = Quaternion.Inverse(Input.gyro.attitude);
        }
        else gyroEnabled = false;
        
    }

    //returns the rotation
    public Quaternion GetGyroRotation()
    {
        return rotation;
    }
    
    public Quaternion GetGyroReferenceRotation()
    {
        return referenceRotation;
    }
    
    public void SetGyroReferenceRotation()
    {
        referenceRotation = Quaternion.Inverse(rotation);
    }
}
