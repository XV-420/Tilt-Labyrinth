using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameEventChannel", menuName = "ScriptableObjects/GameEventChannelSO")]
public class GameEventChannelSO : ScriptableObject
{
        //event for when the level is completed
        public Action<bool, int> OnLevelCompleted;

        public void RaiseOnLevelCompleted(bool specific, int levelToLoad)
        {
            OnLevelCompleted.Invoke(specific, levelToLoad);
        }
}
