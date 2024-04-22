using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TriggerEndOfLevel : MonoBehaviour
{
    //event channel
    [SerializeField] private GameEventChannelSO gameEventChannel;
    [SerializeField] private bool specific = false;
    [SerializeField] private int levelToLoad = 0;
    
    
    //trigger event when hit by the ball
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            gameEventChannel.RaiseOnLevelCompleted(specific, levelToLoad);
        }
    }
}
