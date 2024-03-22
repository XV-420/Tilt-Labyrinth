using UnityEngine;

public class TiltControls : MonoBehaviour
{

    [SerializeField] private Quaternion startRotation = new Quaternion(0, 0, 1, 0);

    void Start()
    {
        //checks gyro support
        GyroManager.Instance.EnableGyro();
    }
    
    //get the x and z rotation from Input
    void Update()
    {
        transform.localRotation = GyroManager.Instance.GetGyroRotation() * startRotation;
    }
}
