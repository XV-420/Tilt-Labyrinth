using System;
using UnityEngine;


public class FollowBall : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    [SerializeField] private float heightAboveBall = 15f;
    [SerializeField] private float swapHeightAboveBall = 30f;

    private bool swapped = false;
    private float height;


    private void Start()
    {
        height = heightAboveBall;
    }

    [SerializeField] private UIEventChannelSO uiEventChannelSo;

    void Update()
    {
        Vector3 pos = ballTransform.position;
        pos.y += height;
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    private void OnEnable()
    {
        uiEventChannelSo.OnCameraSwap += ChangeHeight;
    }

    private void OnDisable()
    {
        uiEventChannelSo.OnCameraSwap -= ChangeHeight;
    }
    
    //change height
    private void ChangeHeight()
    {
        if (!swapped) height = swapHeightAboveBall;
        else height = heightAboveBall;

        swapped = !swapped;

    }

}
