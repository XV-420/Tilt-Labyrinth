using UnityEngine;
using UnityEngine.PlayerLoop;


public class FollowBall : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    [SerializeField] private float heightAboveBall;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = ballTransform.position;
        pos.y += heightAboveBall;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
