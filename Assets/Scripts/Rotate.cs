using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float timer=5;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5) {
        x=Random.Range(-1.0f, 1.0f);
        y = Random.Range(-1.0f, 1.0f);
        z = Random.Range(-1.0f, 1.0f);
            timer = 0;
        }
        if (transform.eulerAngles.x+x < 340 && transform.eulerAngles.x+x > 30)
        {
            if(transform.eulerAngles.x + x < 340)
            {
                if (transform.eulerAngles.x > 180)
                {
                    if (x < 0)
                    {
                        x = 0;
                    }
                }
                else
                {
                    if (x > 0)
                    {
                        x = 0;
                    }
                }
            }
            else
            {
                if (x > 0)
                {
                    x = 0;
                }
            }
        }
        if (transform.eulerAngles.z + z < 340 && transform.eulerAngles.z + z > 30)
        {

            if (transform.eulerAngles.z + z < 340)
            {
                if (transform.eulerAngles.z + z > 180)
                {
                    if (z < 0)
                    {
                        z = 0;
                    }
                }
                else
                {
                    if (z > 0)
                    {
                        z = 0;
                    }
                }
            }
            else
            {
                if (z > 0)
                {
                    z = 0;
                }
            }
        }
        transform.Rotate(x*Time.deltaTime*50, 0, z * Time.deltaTime*50);
    }
}
