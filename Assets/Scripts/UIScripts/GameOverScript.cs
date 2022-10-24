using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text EnemiesKilledText;
    [SerializeField]
    private TMP_Text GoldGainedText;
    [SerializeField]
    private TMP_Text GoldSpentText;
    [SerializeField]
    private TMP_Text HerosReqruitedText;
    [SerializeField]
    private TMP_Text HealingDoneText;
    [SerializeField]
    private TMP_Text TimeKnockedOutText;
    [SerializeField]
    private TMP_Text LevelReachedText;
    [SerializeField]
    private TMP_Text HealthLostText;
    [SerializeField]
    private TMP_Text TowersMadeText;
    [SerializeField]
    private TMP_Text HealthLeftText;
    [SerializeField]
    private TMP_Text GoldLeftText;

    [SerializeField]
    private int enemiesKilledValue;
    [SerializeField]
    private int GoldGainedValue;
    [SerializeField]
    private int GoldSpentValue;
    [SerializeField]
    private int HerosValue;
    [SerializeField]
    private float HealingDoneValue;
    [SerializeField]
    private float TimeKnockedOutValue;
    [SerializeField]
    private int LevelReachedValue;
    [SerializeField]
    private int HealthLostValue;
    [SerializeField]
    private int TowersMadeValue;
    [SerializeField]
    private int HealthLeftValue;
    [SerializeField]
    private int GoldLeftValue;

    private void Start()
    {
        GetValues();
        SetValues();
    }

    private void GetValues()
    {
        enemiesKilledValue = StatTracker.instance.GetEnemyKilled();
        GoldGainedValue = StatTracker.instance.GetGoldGained();
        GoldSpentValue = StatTracker.instance.GetGoldSpent();
        HerosValue = 0;
        TimeKnockedOutValue = 0.0f;
        LevelReachedValue = StatTracker.instance.GetLevel();
        HealingDoneValue = StatTracker.instance.GetHealingDone();
        HealthLeftValue = StatTracker.instance.GetHealthLost();
        TowersMadeValue = StatTracker.instance.GetTowerMade();
        HealthLeftValue = LevelHealthController.instance.GetHealth();
        GoldLeftValue = CurrencyManagerScript.instance.GetGold();
    }

    private void SetValues()
    {
        EnemiesKilledText.text = enemiesKilledValue.ToString();
        GoldGainedText.text = GoldGainedValue.ToString();
        GoldSpentText.text = GoldSpentValue.ToString();
        HerosReqruitedText.text = HerosValue.ToString();
        TimeKnockedOutText.text = TimeKnockedOutValue.ToString();
        LevelReachedText.text = LevelReachedValue.ToString();
        HealingDoneText.text = HealingDoneValue.ToString();
        HealthLostText.text = HealthLostValue.ToString();
        TowersMadeText.text = TowersMadeValue.ToString();
        HealthLeftText.text = HealthLeftValue.ToString();
        GoldLeftText.text = GoldLeftValue.ToString();
    }

    public void OnHomePressed()
    {
        LevelHealthController.instance.DeleteThis();
        StatTracker.instance.DeleteThis();
        CurrencyManagerScript.instance.DeleteThis();
        SceneManager.LoadScene("Main Menu");
    }

    public void OnRetryPressed()
    {
        LevelHealthController.instance.DeleteThis();
        StatTracker.instance.DeleteThis();
        CurrencyManagerScript.instance.DeleteThis();
        SceneManager.LoadScene("Level Select");
    }
}
