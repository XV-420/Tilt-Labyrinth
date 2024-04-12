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

    [SerializeField] private Transform lowBounds;
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

    public void FixedUpdate()
    {
        if(transform.position.y < lowBounds.position.y)
            ResetBall();
    }

    private IEnumerator WaitBeforeRest(GameObject other)
    {
        // suspend execution for 1 second
        yield return new WaitForSeconds(1);
        if (other.gameObject.transform.position.y > transform.position.y)
            ResetBall();
    }
}
