using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartLevelUIManager : MonoBehaviour
{
    //calibrate button
    [SerializeField] private UnityEngine.UI.Button calibrateButton;

    //canvas for the levelUI
    [SerializeField] private UnityEngine.Canvas levelUI;
    
    //canvas for the levelUI
    [SerializeField] private UnityEvent calibrate;

    void Start()
    {
        //disable level UI
        levelUI.enabled = false;
        Time.timeScale = 0;

        //setup onclick (calibrate and enable game ui) pauses game until clicked
        calibrateButton.onClick.AddListener(delegate {   
           calibrate.Invoke();
           levelUI.enabled = true;
           calibrateButton.gameObject.SetActive(false);
           Time.timeScale = 1;
        });
    }
}
