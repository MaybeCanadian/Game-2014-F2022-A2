using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayScript : MonoBehaviour
{
   public void OnBackPressed()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
