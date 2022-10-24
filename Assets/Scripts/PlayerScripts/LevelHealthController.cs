using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*---------------------------------
 * LevelHealthController.cs - Evan Coffey - 101267129
 * 
 * Keeps track of the level health, reduces it when enemies reach the end and shows the lose screen when the game ends.
 * 
 * Version History -
 * 10/23/2022 - created script
 * 
 * Latest Revision -
 * 10/23/2022
 * --------------------------------
 */
public class LevelHealthController : MonoBehaviour
{
   public static LevelHealthController instance;

    [SerializeField]
    private int Health = 100;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void LoseHealth(int amount) //reduces health by the amount
    {
        Health -= amount;

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
        Debug.Log("GAME OVER");
    }

    public int GetHealth()
    {
        return Health;
    }


}
