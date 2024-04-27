using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitArrows : MonoBehaviour
{
    //list of exits
    [SerializeField] private List<Transform> exitPositions = new List<Transform>();

    [SerializeField] private Transform ballSpawn;
   
    //arrow
    [SerializeField] private GameObject arrowPrefab;

    private List<GameObject> exitArrows = new List<GameObject>();
    private List<float> exitDistances = new List<float>();

    [SerializeField] private Transform ballTransform;

    private void Start()
    {
        //zero out y
        Vector3 spawnPos = new Vector3(ballSpawn.position.x, 0.0f, ballSpawn.position.z);
        
        foreach (Transform exit in exitPositions)
        {
            exitArrows.Add(Instantiate(arrowPrefab, ballTransform));
            exitDistances.Add(Vector3.Distance(spawnPos, exit.position));
        }
    }
    
    void Update()
    {
        if (ballTransform)
        {
            for(int i = 0; i < exitPositions.Count; i++)
            {
                //look at exit
                Vector3 target = exitPositions[i].position;
                target.y = ballTransform.position.y;
                exitArrows[i].transform.LookAt(target);

                //scale based on distance relative to stored starting distance
                float distance = Vector3.Distance(ballTransform.position, exitPositions[i].position);
                float scaling = exitDistances[i] / distance;
                if (scaling < 1) scaling = 1;
                
                exitArrows[i].transform.localScale =
                    new Vector3(scaling, 1, scaling);
            }
        }
    }
}
