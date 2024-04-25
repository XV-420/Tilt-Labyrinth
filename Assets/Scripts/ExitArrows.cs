using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitArrows : MonoBehaviour
{
    //list of exits
    [SerializeField] private List<Transform> exitPositions = new List<Transform>();
   
    //arrow
    [SerializeField] private GameObject arrowPrefab;

    private List<GameObject> exitArrows = new List<GameObject>();

    [SerializeField] private Transform ballTransform;

    private void Start()
    {
        foreach (Transform exit in exitPositions)
            exitArrows.Add(Instantiate(arrowPrefab, ballTransform));
    }

    void Update()
    {
        if (ballTransform)
        {
            for(int i = 0; i < exitPositions.Count; i++)
            {
                //debugging rays
                Debug.DrawRay(ballTransform.position, exitPositions[i].position - ballTransform.position, Color.yellow);
                Vector3 target = exitPositions[i].position;
                exitArrows[i].transform.LookAt(target);

            }
        }
    }
}
