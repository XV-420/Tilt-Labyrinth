using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevelUIManager : MonoBehaviour
{
    //calibrate button
    [SerializeField] private UnityEngine.UI.Button calibrateButton;

    //canvas for the levelUI
    [SerializeField] private UnityEngine.Canvas levelUI;

    void Start()
    {
        //disable level UI
        levelUI.enabled = false;
        Time.timeScale = 0;

        //setup onclick (calibrate and enable game ui) pauses game until clicked
        calibrateButton.onClick.AddListener(delegate {   
            levelUI.enabled = true;
            GyroManager.Instance.SetGyroReferenceRotation();
            calibrateButton.gameObject.SetActive(false);
            Time.timeScale = 1;
        });
    }
}
