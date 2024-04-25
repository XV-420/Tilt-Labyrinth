using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    [Header("Event Channels")]
    [SerializeField] private UIEventChannelSO uiEventChannelSo;

    [Header("Buttons")]
    [SerializeField] private UnityEngine.UI.Button startGameButton;
    
    [SerializeField] private UnityEngine.UI.Button quitGameButton;
    
    // Start is called before the first frame update
    void Start()
    {
        startGameButton.onClick.AddListener(delegate
        {
            uiEventChannelSo.RaiseOnNextLevel(false, 0);
        });
        
        quitGameButton.onClick.AddListener(delegate
        {
            uiEventChannelSo.RaiseOnQuit();
        });
    }
}
