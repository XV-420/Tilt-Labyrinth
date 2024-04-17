using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "UIEventChannel", menuName = "ScriptableObjects/UIEventChannelSO")]
public class UIEventChannelSO : ScriptableObject
{
 
    //event for when the level is completed
    public UnityAction OnLevelCompleted;

    public void RaiseOnLevelCompleted()
    {
        OnLevelCompleted.Invoke();
    }
    
    //what happens when next level is clicked
    public UnityAction OnNextLevel;
    public void RaiseOnNextLevel()
    {
        OnNextLevel.Invoke();
    }
    
    //what happens when main menu is clicked
    public UnityAction OnMainMenu;

    public void RaiseOnMainMenu()
    {
        OnMainMenu.Invoke();
    }
    
    //trigger for when the calibrate is called
    public UnityAction OnCalibrate;

    public void RaiseOnCalibrate()
    {
        OnCalibrate.Invoke();
    }
    
    //Trigger for when reset is called
    public UnityAction OnReset;

    public void RaiseOnReset()
    {
        OnReset.Invoke();
    }
}
