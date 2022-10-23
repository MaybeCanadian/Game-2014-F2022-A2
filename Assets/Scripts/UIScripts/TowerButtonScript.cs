using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
/*-------------------------------------------
 * TowerButtonScript.cs - Evan Coffey - 101267129
 * 
 * Controls the buttons, what thet show and say and talks to the tower spawning script
 * 
 * Version History -
 * 10/23/2022 - created script, stopped working on it for now
 * 
 * Latest Revision -
 * 10/23/2022
 * ------------------------------------------
 */

public class TowerButtonScript : MonoBehaviour
{
    [SerializeField]
    private Image TowerImage;
    [SerializeField]
    private Button TowerButton;
    [SerializeField]
    private Text TowerText;

    private void Start()
    {
        TowerText = TowerButton.GetComponentInChildren<Text>();
    }

    public void SetText(string text)
    {
        TowerText.text = text;
    }

    public void SetImage(Sprite image)
    {
        TowerImage.sprite = image;
    }
}
