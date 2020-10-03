using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostInteractions : MonoBehaviour
{
    CredibilityManager credibility;
    PostContent content;
    
    private void Start() 
    {
        credibility = FindObjectOfType<CredibilityManager>(); 
        content = GetComponent<PostDisplay>().content; 
    }

    public void Liked()
    {
        // add to favorite posts
    }

    public void Disliked()
    {
    }

    public void Shared()
    {
        credibility.ModifyCredibility(content.scoreModifier);
        TriggerSharedVFX();
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
