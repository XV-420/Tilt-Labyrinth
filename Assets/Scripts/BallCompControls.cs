using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCompControls : MonoBehaviour
{
    private Rigidbody ballRigidBody;
    [SerializeField] private float speed = 200.0f;
    [SerializeField] private float heightOfInputCancelation = 2.5f;
    [SerializeField] private float maxJumpSpeed = 5.0f;

    [SerializeField] private Transform lowBoundsForJump;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody>();
        lowBoundsForJump = GetComponent<Ball>().GetLowBounds();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position.y + " " + (lowBoundsForJump.position.y + heightOfInputCancelation));
        //if off the board remove xz input or velocity
        if (transform.position.y < lowBoundsForJump.position.y + heightOfInputCancelation)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 z = new Vector3(0, 0, 1);
                ballRigidBody.AddForce(z * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                Vector3 z = new Vector3(0, 0, -1);
                ballRigidBody.AddForce(z * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                Vector3 x = new Vector3(-1, 0, 0);
                ballRigidBody.AddForce(x * speed * Time.deltaTime);


            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Vector3 x = new Vector3(1, 0, 0);
                ballRigidBody.AddForce(x * speed * Time.deltaTime);


            }

            //jumping
            //check jump velocity and clamp
            if (ballRigidBody.velocity.y > maxJumpSpeed)
                ballRigidBody.velocity = new Vector3(ballRigidBody.velocity.x, maxJumpSpeed, ballRigidBody.velocity.z);
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.X))
            {
                Vector3 y = new Vector3(0, 1, 0);
                ballRigidBody.AddForce(y * maxJumpSpeed * Time.deltaTime);
            }

        }
    }
}
