using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostDisplay : MonoBehaviour
{
    [SerializeField] public PostContent content = null;
    
    [Header("UI References")]
    [SerializeField] TextMeshProUGUI profile = null;
    [SerializeField] TextMeshProUGUI headline = null;
    [SerializeField] Image featureImage = null;
    [SerializeField] TextMeshProUGUI source = null;

    private void Start() 
    {
        profile.text = content.profileText;
        headline.text = content.headlineText;
        featureImage.sprite = content.featureImage;
        source.text = content.sourceText;
    }
}
