using UnityEngine;
using UnityEngine.PlayerLoop;


public class FollowBall : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    [SerializeField] private float heightAboveBall;

    private float startingYPos;

    private void Start()
    {
        startingYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = ballTransform.position;
        if(pos.y > startingYPos)
            pos.y = pos.y - startingYPos;
        pos.y += heightAboveBall;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
