using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCompControls : MonoBehaviour
{
    private Rigidbody ballRigidBody;
    [SerializeField] private float speed = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            Vector3 x = new Vector3(-1, 0, 0);
            ballRigidBody.AddForce(x * speed * Time.deltaTime);
            

        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Vector3 x = new Vector3(1, 0, 0);
            ballRigidBody.AddForce(x * speed * Time.deltaTime);
           

        }
    }
}
