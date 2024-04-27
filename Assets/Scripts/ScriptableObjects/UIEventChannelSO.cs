using System;
using UnityEngine;
[CreateAssetMenu(fileName = "UIEventChannel", menuName = "ScriptableObjects/UIEventChannelSO")]
public class UIEventChannelSO : ScriptableObject
{
    //what happens when next level is clicked
    public Action<bool, int> OnNextLevel;
    public void RaiseOnNextLevel(bool loadSpecificLevel, int levelToLoad)
    {
        OnNextLevel.Invoke(loadSpecificLevel, levelToLoad);
    }
    
    //trigger when main menu is clicked
    public Action OnMainMenu;

    public void RaiseOnMainMenu()
    {
        OnMainMenu.Invoke();
    }
    
    //trigger for when the calibrate is called
    public Action OnCalibrate;

    public void RaiseOnCalibrate()
    {
        OnCalibrate.Invoke();
    }
    
    //Trigger for when reset is called
    public Action OnReset;

    public void RaiseOnReset()
    {
        OnReset.Invoke();
    }
    
    //Trigger for when reset is called
    public Action OnQuit;

    public void RaiseOnQuit()
    {
        OnQuit.Invoke();
    }
    
    //Trigger for when camera is swapped
    public Action OnCameraSwap;

    public void RaiseOnCamaraSwap()
    {
        OnCameraSwap.Invoke();
    }
}
