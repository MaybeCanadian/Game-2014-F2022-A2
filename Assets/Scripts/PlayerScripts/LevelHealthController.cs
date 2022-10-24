using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*---------------------------------
 * LevelHealthController.cs - Evan Coffey - 101267129
 * 
 * Keeps track of the level health, reduces it when enemies reach the end and shows the lose screen when the game ends.
 * 
 * Version History -
 * 10/23/2022 - created script
 * 10/24/2022 - made running out of health send you to the game over screen
 * 
 * Latest Revision -
 * 10/24/2022
 * --------------------------------
 */
public class LevelHealthController : MonoBehaviour
{
   public static LevelHealthController instance;

    [SerializeField]
    private int Health = 100;

    [Header("Debug Bool")]
    [SerializeField]
    private bool SkipLevel = false;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(SkipLevel)
        {
            OutOfHealth();
        }
    }

    public void LoseHealth(int amount) //reduces health by the amount
    {
        Health -= amount;
        StatTracker.instance.AddHealthLost(amount);

        if(Health <= 0)
        {
            OutOfHealth();
        }
    }

    public void GainHealth(int amount)
    {
        Health += amount;
    }

    private void OutOfHealth()
    {
        SceneManager.LoadScene("GameLose");
    }

    public int GetHealth()
    {
        return Health;
    }

    public void DeleteThis() 
    {
        Destroy(gameObject);
    }
}
