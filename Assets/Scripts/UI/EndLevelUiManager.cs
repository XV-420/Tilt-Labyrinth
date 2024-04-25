using UnityEngine;

public class EndLevelUiManager : MonoBehaviour
{
    [Header("Event Channels")]
    [SerializeField] private UIEventChannelSO uiEventChannelSo;
    //event channel
    [SerializeField] private GameEventChannelSO gameEventChannelSo;

    
    //buttons
    //main menu button
    [Header("Buttons")]
    [SerializeField] private UnityEngine.UI.Button mainMenuButton;
    
    //next level button
    [SerializeField] private UnityEngine.UI.Button nextLevelButton;

    //canvas for the levelUI
    private Canvas levelEndUI;
    
    //level loading data
    private int levelToLoad;
    private bool loadSpecificLevel;
    
    //set up event listeners
    private void OnEnable()
    {
        gameEventChannelSo.OnLevelCompleted += EnableUI;
    }
    private void OnDisable()
    {
        gameEventChannelSo.OnLevelCompleted -= EnableUI;
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
            uiEventChannelSo.RaiseOnNextLevel(loadSpecificLevel, levelToLoad);
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
    void EnableUI(bool loadSpecificLevel, int levelToLoad)
    {
        this.loadSpecificLevel = loadSpecificLevel;
        this.levelToLoad = levelToLoad;
        levelEndUI.enabled = true;
        Time.timeScale = 0;
    }
}
