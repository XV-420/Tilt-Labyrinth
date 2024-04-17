using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "UIEventChannel", menuName = "ScriptableObjects/UIEventChannelSO")]
public class UIEventChannelSO : ScriptableObject
{
 
    //what happens when the main menu is loaded
    public UnityAction OnLevelCompleted;

    public void RaiseOnLevelCompleted()
    {
        OnLevelCompleted.Invoke();
    }
}
