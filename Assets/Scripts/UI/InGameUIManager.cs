using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InGameUIManager : MonoBehaviour
{
    //calibrate button
    [SerializeField] private UnityEngine.UI.Button calibrateButton;
    
    //calibrate button
    [SerializeField] private UnityEngine.UI.Button spawnBallButton;
    
    [SerializeField] private UnityEvent ballSpawnEvent;
    
    [SerializeField] private UnityEvent calibrate;
    
    void Start()
    {
        //setup onclick of the calibrate 
        calibrateButton.onClick.AddListener(delegate {   
           calibrate.Invoke();
        });
        
        //set up the ball spawn event
        spawnBallButton.onClick.AddListener(delegate {   
            ballSpawnEvent.Invoke();
        });
        
        
    }
}
