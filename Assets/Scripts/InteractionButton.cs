using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionButton : MonoBehaviour
{
    private void Start() 
    {
        GetComponent<Button>().onClick.AddListener(PlaySFX);
        
    }

    public void TriggerClickedAffordance()
    {
        GetComponent<Button>().interactable = false;
    }

    private void PlaySFX()
    {
        FindObjectOfType<AudioManager>().Play("click");
    }
}
