using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    private string[] sceneNames = {"Menu", "Level1", "Level2", "Level3", "Lose", "Victory"};
    private int currentSceneIndex = 0; // Index of the currently loaded scene
    private int lastLevel = 1; // Default to Level1 initially

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Load the scene at the given index
    private void LoadSceneAtIndex(int index)
    {
        SceneManager.LoadScene(sceneNames[index]);
        currentSceneIndex = index;
    }

    // Remember the last level
    private void RememberLastLevel()
    {
        if (currentSceneIndex >= 1 && currentSceneIndex <= 3)
        {
            lastLevel = currentSceneIndex;
        }
    }

    // Load the previous scene
    public void LoadPreviousScene()
    {
       
        int previousIndex = (currentSceneIndex - 1 + sceneNames.Length) % sceneNames.Length;
        LoadSceneAtIndex(previousIndex);
    }

    // Load a specific scene by name
    public void LoadLevel1()
    {
        
        SceneManager.LoadScene("Level1");
    }

    public void LoadMenu()
    {
        
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevel2()
    {
        
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        
        SceneManager.LoadScene("Level3");
    }


    public void LoadNextLevel()
    {
        
        int nextIndex = (currentSceneIndex + currentSceneIndex++) % sceneNames.Length;
        if (nextIndex >= 1 && nextIndex <= 3)
        {
            // If the next scene is a level, load it
            LoadSceneAtIndex(nextIndex);
            nextIndex = 0;
        }
    }

    public void LoadPreviousLevel()
    {
        if (lastLevel == 1)
        {
            // If the last level was Level 1, restart it
            SceneManager.LoadScene("Level1");
        }
        else if (lastLevel == 2)
        {
            // If the last level was Level 2, go back to Level 1
            SceneManager.LoadScene("Level1");
        }
        else if (lastLevel == 3)
        {
            // If the last level was Level 3, go back to Level 2
            SceneManager.LoadScene("Level2");
        }
    }

    public void DevWebPage()
    {
        UnityEngine.Application.OpenURL("https://github.com/b00144312?tab=repositories");
    }

    public void CodeRepo()
    {
        UnityEngine.Application.OpenURL("https://github.com/Stan-T-Pet/Heavy-Thrust");
    }
}
