using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSoundEffects : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip loseBGM, winBGM, menuBGM, LV1, LV2, LV3;

    void Start()
    {
        //Call OnSceneLoaded when the scene loads
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Play BGM for main scenes on start
        PlayMenuBGM();
    }

    void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check the loaded scene and play the scene's sound
        string sceneName = scene.name;

        switch (sceneName)
        {
            case "Menu":
                PlayMenuBGM();
                break;

            case "Level1":
                PlayLV1BGM();
                break;

            case "Level2":
                PlayLV2BGM();
                break;

            case "Level3":
                PlayLV3BGM();
                break;

            case "Victory":
                PlayWinBGM();
                break;

            case "Lose":
                PlayLoseBGM();
                break;

            default:
                break;
        }
    }

    public void PlayLoseBGM()
    {
        soundSource.clip = loseBGM;
        soundSource.Play();
    }

    public void PlayWinBGM()
    {
        soundSource.clip = winBGM;
        soundSource.Play();
    }

    public void PlayLV1BGM()
    {
        soundSource.clip = LV1;
        soundSource.Play();
    }

    public void PlayLV2BGM()
    {
        soundSource.clip = LV2;
        soundSource.Play();
    }

    public void PlayLV3BGM()
    {
        soundSource.clip = LV3;
        soundSource.Play();
    }

    public void PlayMenuBGM()
    {
        soundSource.clip = menuBGM;
        soundSource.Play();
    }

}
