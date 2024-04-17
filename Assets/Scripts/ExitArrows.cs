using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitArrows : MonoBehaviour
{
    [SerializeField] private List<Transform> exitPositions = new List<Transform>();
    // Start is called before the first frame update

    [SerializeField] private Transform ballTransform;
    // Update is called once per frame
    void Update()
    {
        foreach (Transform t in exitPositions)
        {
            //debugging rays
            Debug.DrawRay(ballTransform.position,   t.position-ballTransform.position, Color.yellow);
        }
    }
}
