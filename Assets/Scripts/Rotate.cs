using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float timer=0;
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
        if(timer > 3) {
        x=Random.Range(-1.0f, 1.0f);
        y = Random.Range(-1.0f, 1.0f);
        z = Random.Range(-1.0f, 1.0f);
            timer = 0;
        }
        if (transform.eulerAngles.x+x < 340 && transform.eulerAngles.x+x >= 30)
        {
            x = 0;
        }
        if (transform.eulerAngles.z + z < 340 && transform.eulerAngles.z + z >= 30)
        {
            z = 0;
        }
        transform.Rotate(x*Time.deltaTime*50, 0, z * Time.deltaTime*50);
    }
}
