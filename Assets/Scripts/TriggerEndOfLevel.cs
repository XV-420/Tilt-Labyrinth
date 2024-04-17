using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TriggerEndOfLevel : MonoBehaviour
{
    //event channel
    [SerializeField] private GameEventChannelSO gameEventChannel;
    
    
    //trigger event when hit by the ball
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
            gameEventChannel.RaiseOnLevelCompleted();
    }
}
