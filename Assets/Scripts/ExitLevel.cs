using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    //event channel
    [Header("Event Channels")]
    [SerializeField] private UIEventChannelSO uiEventChannel;

    private int sceneCount; //count of the scenes in the game
    
    //subscribe(listen) to on level completed and main menu events
    private void OnEnable()
    {
        uiEventChannel.OnNextLevel += LoadNextLevel;
        uiEventChannel.OnMainMenu += LoadMainMenu;
    }
    private void OnDisable()
    {
        uiEventChannel.OnNextLevel -= LoadNextLevel;
        uiEventChannel.OnMainMenu -= LoadMainMenu;
    }
    

    // get built scenes
    void Start()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    
    
    //loads the next level, defaults to main menu if fails
    private void LoadNextLevel()
    {
        //load the next scene if it exists, otherwise go the the main menu
        //main menu is 0! 
        int sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        //if scene is valid load
        
        if (sceneToLoad <= sceneCount)
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        else //load the main menu, 0
            SceneManager.LoadScene(0);
    }
    
    //loads a level at the index
    private void LoadSpecificLevel(int sceneToLoad)
    {
        //if scene is valid load
        if (sceneToLoad <= sceneCount)
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        else //load the main menu, 0
            SceneManager.LoadScene(0);
    }
    
    //loads the level 0 (main menu)
    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
