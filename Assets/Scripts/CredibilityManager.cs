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
        PlaySFX(amount);

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
        FindObjectOfType<AudioManager>().Play("win");
    }

    private void TriggerLostCondition()
    {
        lostScreen.SetActive(true);
        FindObjectOfType<AudioManager>().Play("lose");
    }

    private void UpdateSliderValue()
    {
        Slider slider = GetComponent<Slider>();
        slider.value = credibilityScore;
    }

    private void PlaySFX(float amount)
    {
        if (amount > 0)
        {
            FindObjectOfType<AudioManager>().Play("goodShare");
        }
        else if (amount < 0)
        {
            FindObjectOfType<AudioManager>().Play("badShare");
        }
        else
        {
            Debug.Log("Content has a 0 score modifier");
        }
    }
}
