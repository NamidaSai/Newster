using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CredibilityManager : MonoBehaviour
{
    [SerializeField] float winScore = 100f;
    [SerializeField] float lostScore = 0f;
    [SerializeField] GameObject winScreen = default;
    [SerializeField] GameObject lostScreen = default;

    float credibilityScore = 50f;

    private void Awake() 
    {
        winScreen.SetActive(false);
        lostScreen.SetActive(false);
    }

    public void ModifyCredibility(float amount)
    {
        credibilityScore += amount;
        UpdateSliderValue();

        if (credibilityScore >= winScore)
        {
            TriggerWinCondition();
        }

        if (credibilityScore <= lostScore)
        {
            TriggerLostCondition();
        }
    }

    private void TriggerWinCondition()
    {
        winScreen.SetActive(true);
    }

    private void TriggerLostCondition()
    {
        lostScreen.SetActive(true);
    }

    private void UpdateSliderValue()
    {
        Slider slider = GetComponent<Slider>();
        slider.value = credibilityScore;
    }
}
