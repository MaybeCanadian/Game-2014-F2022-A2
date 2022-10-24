using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void OnEmbarkPressed()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void OnHowToPlayPressed()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void OnMyHeroesPressed()
    {
        Debug.Log("not added yet");
    }

    public void OnSettingsPressed()
    {
        Debug.Log("not added yet");
    }

    public void OnAchievementsPressed()
    {
        Debug.Log("not added yet");
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }
}
