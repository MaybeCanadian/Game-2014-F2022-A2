using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//--------------------------------------------------------------------------------------
//  Code By Evan Coffey for Dungeon Quest - 101267129

//  Changes -
//  Oct 3rd 2022 - file created
//--------------------------------------------------------------------------------------

public class ChangeScene : MonoBehaviour
{
    private bool waitToSwitch;
    private void Start()
    {
        waitToSwitch = true;
        Invoke("OkayToSwitch", 1.0f);
    }

    private void OkayToSwitch()
    {
        waitToSwitch = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && !waitToSwitch)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
