using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineController : MonoBehaviour
{
    [SerializeField] GameObject postPrefab = default;
    [SerializeField] List<PostContent> contentCollection = new List<PostContent>();

    LevelController levelController;

    private void Awake() 
    {
        levelController = FindObjectOfType<LevelController>();
    }

    public void RefreshTimeline()
    {
        SelectContentCollection();

        foreach (PostContent content in contentCollection)
        {
            CreateNewPost(content);
        }
    }
    
    private void SelectContentCollection()
    {
        contentCollection = levelController.GetContentCollection();
    }
    
    public void CreateNewPost(PostContent content)
    {
        GameObject newPost = Instantiate(postPrefab, transform.position, transform.rotation) as GameObject;
        newPost.transform.SetParent(this.transform, false);
        newPost.GetComponent<PostDisplay>().content = content;
    }
}
