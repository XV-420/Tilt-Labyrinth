using UnityEngine;

public class TiltControls : MonoBehaviour
{
    [Header("limit Rotation")] 
    [SerializeField] private float maxXRotation = 45.0f;
    [SerializeField] private float minXRotation = -45.0f;
    [SerializeField] private float maxZRotation = 45.0f;
    [SerializeField] private float minZRotation = -45.0f;
    private Quaternion startRotation = new Quaternion(0, 0, 1, 0);
    
    void Start()
    {
        //checks gyro support
        GyroManager.Instance.EnableGyro();
    }
    
    //get the x and z rotation from Input
    void Update()
    {
        //get input
        transform.localRotation= GyroManager.Instance.GetGyroRotation(); //* startRotation;
        
        //transform.localRotation = new Quaternion(temp.x, 0.0f,
         //-temp.y, temp.w);
        
        //LimitRot();

    }

    
    //idk I tried
    private void LimitRot()
    {
        Vector3 eulerAngles = transform.localRotation.eulerAngles;

        eulerAngles.x = (eulerAngles.x > 180) ? eulerAngles.x - 360 : eulerAngles.y;
        eulerAngles.x = Mathf.Clamp(eulerAngles.x, minXRotation, maxXRotation);

        //eulerAngles.z = (eulerAngles.y > 180) ? eulerAngles.y - 180 : eulerAngles.y;
        //eulerAngles.z = Mathf.Clamp(eulerAngles.y, minZRotation, maxZRotation);
        
        Quaternion change = Quaternion.Euler(eulerAngles);
        
        transform.localRotation = new Quaternion(change.x, 0.0f, -transform.localRotation.y, transform.localRotation.w);
    }
}
