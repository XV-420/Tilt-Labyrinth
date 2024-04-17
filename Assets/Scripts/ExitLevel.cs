using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    //event channel
    [SerializeField] private UIEventChannelSO uiEventChannel;
    
    private int sceneCount;
    
    //subscribe to on level completed
    private void OnEnable()
    {
        uiEventChannel.OnLevelCompleted += LoadNextLevel;
    }
    private void OnDisable()
    {
        uiEventChannel.OnLevelCompleted -= LoadNextLevel;
    }
    

    // get built scenes
    void Start()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    
    
    //loads the next level, defaults to main menu if fails
    public void LoadNextLevel()
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
    public void LoadSpecificLevel(int sceneToLoad)
    {
        //if scene is valid load
        if (sceneToLoad <= sceneCount)
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        else //load the main menu, 0
            SceneManager.LoadScene(0);
    }
    
    //loads the level 0 (main menu)
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
