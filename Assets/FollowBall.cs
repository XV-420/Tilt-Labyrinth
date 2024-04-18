using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowBall : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = ballTransform.position;
        transform.position = new Vector3(pos.x, pos.y+20, pos.z);
    }
}
