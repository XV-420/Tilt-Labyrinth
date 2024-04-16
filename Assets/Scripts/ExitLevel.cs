using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class ExitLevel : MonoBehaviour
{
    
    // box collider
    private BoxCollider exitCollider;

    public int sceneCount;
    

    // Start is called before the first frame update
    void Start()
    {
        exitCollider = GetComponent<BoxCollider>();
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    private void OnTriggerEnter(Collider other)
    {
        //check if ball
        if (other.CompareTag("Ball"))
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
    }
}
