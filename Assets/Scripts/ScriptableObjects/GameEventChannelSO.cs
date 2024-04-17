using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameEventChannel", menuName = "ScriptableObjects/GameEventChannelSO")]
public class GameEventChannelSO : ScriptableObject
{
        //event for when the level is completed
        public UnityAction OnLevelCompleted;

        public void RaiseOnLevelCompleted()
        {
            OnLevelCompleted.Invoke();
        }
}
