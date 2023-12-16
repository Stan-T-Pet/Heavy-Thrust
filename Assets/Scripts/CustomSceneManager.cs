using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    private List<string> sceneHistory = new List<string>();
    private string currentLevel;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject); // Don't delete when a new scene loads
    }

    public void LoadLevel1()
    {
        // Check the current level
        if (currentLevel == "Level1")
        {
            // Restart the current level
            RestartCurrentLevel();
        }else
        {
            // Load "Level1" and add to the history
            AddToHistory("Level1");
            SceneManager.LoadScene("Level1");
        }
    }

    public void LoadMenu()
    {
        AddToHistory("Menu");
        SceneManager.LoadScene("Menu");
    }

    public void LoadLevel2()
    {
        AddToHistory("Level2");
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        AddToHistory("Level3");
        SceneManager.LoadScene("Level3");
    }

    public void RestartCurrentLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void LoadPreviousLevel()
    {
        if (sceneHistory.Count > 1)
        {
            string previousScene = sceneHistory[sceneHistory.Count - 2];
            sceneHistory.RemoveAt(sceneHistory.Count - 1);
            SceneManager.LoadScene(previousScene);
        }
    }

    private void AddToHistory(string sceneName)
    {
        sceneHistory.Add(sceneName);
        currentLevel = sceneName;
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
