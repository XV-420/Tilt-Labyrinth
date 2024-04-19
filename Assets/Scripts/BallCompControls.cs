using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCompControls : MonoBehaviour
{
    private Rigidbody ballRigidBody;
    [SerializeField] private float speed = 200.0f;
    
    [SerializeField] private float maxJumpSpeed = 5.0f;
    [SerializeField] private LayerMask m_LayerMask;
    
    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Forces After:" + ballRigidBody.velocity);
        //if off the board remove xz input or velocity
        Collider[] hitColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, m_LayerMask);
        int i = 0;
        if (hitColliders.Length>0)
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
                
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.X))
                {
                    float x = ballRigidBody.velocity.x;
                    float z = ballRigidBody.velocity.z;
                    ballRigidBody.velocity = new Vector3(x, 0, z);
                    Debug.Log("Forces Before:" + ballRigidBody.velocity);
                    Vector3 y = new Vector3(0, 1, 0);
                   
                    ballRigidBody.AddForce(y * maxJumpSpeed*Time.deltaTime);
                }
           
        }
        
    }
}
