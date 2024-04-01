using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Floats for where the ball is reset to when reset is called")]
    [SerializeField] private float x;

    [SerializeField] private float y;

    [SerializeField] private float z;
    
    //function to reset the ball to certain pos
    public void ResetBall()
    {
        transform.position = new Vector3(x, y, z);
    }
}
