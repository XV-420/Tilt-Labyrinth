using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Position for where the ball is reset to when reset is called")]
    [SerializeField] private Transform spawnPos;

    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    //function to reset the ball to certain pos
    public void ResetBall()
    {
        transform.position = spawnPos.position;
        rigidBody.velocity = Vector3.zero;
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log(other.gameObject.layer);
        if (other.gameObject.layer == 3)
        {
            StartCoroutine(WaitBeforeRest());
        }
    }
    
    IEnumerator WaitBeforeRest()
    {
        // suspend execution for 1 second
        yield return new WaitForSeconds(1);
        ResetBall();
    }
}
