using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostInteractions : MonoBehaviour
{
    [SerializeField] PostType type = default;
    
    private void Awake() 
    {
       type = GetComponent<PostDisplay>().content.type; 
    }

    public void Liked()
    {
        //update affordance
        // add to favorite posts
    }

    public void Disliked()
    {
        // update affordance
    }

    public void Shared()
    {
        // update affordance
        
        if (type == PostType.News)
        {
            // increase credibility
            return;
        }

        if (type == PostType.Fake)
        {
            // decrease credibility
            return;
        }

        else
        {
            // do nothing
            return;
        }
    }
}
