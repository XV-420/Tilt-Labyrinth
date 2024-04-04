using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Position for where the ball is reset to when reset is called")]
    [SerializeField] private GameObject spawnPos;

    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    //function to reset the ball to certain pos
    public void ResetBall()
    {
        transform.position = spawnPos.transform.position;
        rigidBody.velocity = Vector3.zero;
    }
}
