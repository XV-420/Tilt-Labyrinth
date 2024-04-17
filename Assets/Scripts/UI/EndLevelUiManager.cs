using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EndLevelUiManager : MonoBehaviour
{
    [Header("Event Channels")]
    [SerializeField] private UIEventChannelSO uiEventChannelSo;
    //event channel
    [SerializeField] private GameEventChannelSO GameEventChannelSo;

    
    //buttons
    //main menu button
    [SerializeField] private UnityEngine.UI.Button mainMenuButton;
    
    //next level button
    [SerializeField] private UnityEngine.UI.Button nextLevelButton;

    //canvas for the levelUI
    private UnityEngine.Canvas levelEndUI;
    
    //set up event listeners
    private void OnEnable()
    {
        GameEventChannelSo.OnLevelCompleted += EnableUI;
    }
    private void OnDisable()
    {
        GameEventChannelSo.OnLevelCompleted -= EnableUI;
    }
    
    private void Start()
    {
        //get the canvas
        levelEndUI = GetComponent<Canvas>();
        
        //set up the onclicks of the buttons
        mainMenuButton.onClick.AddListener(delegate
        {
            uiEventChannelSo.RaiseOnMainMenu();
            Time.timeScale = 1;
        });
        
        //next level click
        nextLevelButton.onClick.AddListener(delegate
        {
            uiEventChannelSo.RaiseOnNextLevel();
            Time.timeScale = 1;
        });
        
        //disable UI
        DisableUI();
        
        
        
    }
    
    //disable UI Method
    void DisableUI()
    {
        levelEndUI.enabled = false;
    }
    
    //Enable UI Method
    void EnableUI()
    {
        levelEndUI.enabled = true;
        Time.timeScale = 0;
    }
}
