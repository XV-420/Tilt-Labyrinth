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
        if (hitColliders.Length>0)
        {
                Vector3 forces = Vector3.zero;
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    forces = new Vector3(forces.x, forces.y, forces.z + 1);
                }
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
                {
                    forces = new Vector3(forces.x, forces.y, forces.z -1);
                }
                if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                {
                    forces = new Vector3(forces.x-1, forces.y, forces.z);
                }
                if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                {
                    forces = new Vector3(forces.x+1, forces.y, forces.z);
                }

                //jumping
                //check jump velocity and clamp
                
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.X))
                {
                    float x = ballRigidBody.velocity.x;
                    float z = ballRigidBody.velocity.z;
                    //forces = new Vector3(forces.x, forces.y + 1, forces.z);
                    //forces = new Vector3(forces.x, 0, forces.z);
                    //forces.y *= maxJumpSpeed;
                    ballRigidBody.velocity = new Vector3(x, maxJumpSpeed, z);
                }
                
                ballRigidBody.AddForce(forces * speed * Time.deltaTime);
        }
        
    }
}
