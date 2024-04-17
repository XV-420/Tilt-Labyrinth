using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private UIEventChannelSO uiEventChannelSo;

    [SerializeField] private UnityEngine.UI.Button startGameButton;
    
    // Start is called before the first frame update
    void Start()
    {
        startGameButton.onClick.AddListener(delegate
        {
            uiEventChannelSo.RaiseOnNextLevel();
        });
    }
}
