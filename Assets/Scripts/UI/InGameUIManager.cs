using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private UIEventChannelSO uiEventChannelSo;
    
    [Header("Unity UI Buttons")]
    //options button
    [SerializeField] private UnityEngine.UI.Button optionsButton;
    
    //calibrate button
    [SerializeField] private UnityEngine.UI.Button calibrateButton;
    
    //calibrate button
    [SerializeField] private UnityEngine.UI.Button spawnBallButton;
    
    //main menu button
    [SerializeField] private UnityEngine.UI.Button mainMenuButton;
    
    //main menu button
    [SerializeField] private UnityEngine.UI.Button resumeButton;
    
    //camera
    [SerializeField] private UnityEngine.UI.Button cameraSwapButton;

    [Header("Unity UI Elements")]
    //panel for options background
    [SerializeField] private GameObject backgroundOptionsPanel;
    
    void Start()
    {
        //camera sawp button
        cameraSwapButton.onClick.AddListener(delegate {   
            uiEventChannelSo.RaiseOnCamaraSwap();
        });
        
        //setup onclick of the calibrate unpauses
        calibrateButton.onClick.AddListener(delegate {   
            uiEventChannelSo.RaiseOnCalibrate();
            DisableUI();
            Time.timeScale = 1;
        });
        
        //set up the ball spawn event unpauses
        spawnBallButton.onClick.AddListener(delegate {   
            uiEventChannelSo.RaiseOnReset();
            uiEventChannelSo.RaiseOnCalibrate();
            DisableUI();
            Time.timeScale = 1;
        });
        
        //set up resume button unpauses
        resumeButton.onClick.AddListener(delegate
        {
            DisableUI();
            Time.timeScale = 1;
        });
        
        mainMenuButton.onClick.AddListener(delegate
        {
            uiEventChannelSo.RaiseOnMainMenu();
        });
        
        //hide panel and other ui buttons
        DisableUI();
        
        //setup options onclick pauses
        optionsButton.onClick.AddListener(delegate
        {
            EnableUI();
            Time.timeScale = 0;
        });
        
    }

    //hides the options button and shows the options menu
    private void EnableUI()
    {
        optionsButton.gameObject.SetActive(false);
        backgroundOptionsPanel.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        calibrateButton.gameObject.SetActive(true);
        spawnBallButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
    }
    /// <summary>
    /// Enables the options and disables the rest
    /// </summary>
    private void DisableUI()
    {
        optionsButton.gameObject.SetActive(true);
        backgroundOptionsPanel.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        calibrateButton.gameObject.SetActive(false);
        spawnBallButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
    }
}
