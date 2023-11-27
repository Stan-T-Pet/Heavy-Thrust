using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class CustomSceneManager : MonoBehaviour
{
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

    public void DevWebPage()
    {
        UnityEngine.Application.OpenURL("https://github.com/b00144312?tab=repositories");
    }

    public void CodeRepo()
    {
        UnityEngine.Application.OpenURL("https://github.com/Stan-T-Pet/Heavy-Thrust");
    }
}
