using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostInteractions : MonoBehaviour
{
    CredibilityManager credibility;
    PostContent content;
    AudioManager audioManager;
    
    private void Start() 
    {
        credibility = FindObjectOfType<CredibilityManager>(); 
        content = GetComponent<PostDisplay>().content;
        audioManager = FindObjectOfType<AudioManager>(); 
    }

    public void Liked()
    {
        // add to favorite posts
        audioManager.Play("liked");
    }

    public void Disliked()
    {
        audioManager.Play("disliked");
    }

    public void Shared()
    {
        credibility.ModifyCredibility(content.scoreModifier);
        TriggerSharedVFX();
        audioManager.Play("shared");
    }

    private void TriggerSharedVFX()
    {
        if (content.type == PostType.News)
        {
            // trigger positive vfx
        }
        else if (content.type == PostType.Fake)
        {
            // trigger negative vfx
        }
        else
        {
            return;
        }
    }
}
