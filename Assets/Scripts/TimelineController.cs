using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineController : MonoBehaviour
{
    [SerializeField] float delayBetweenNewPosts = 0.5f;
    [SerializeField] GameObject postPrefab = default;
    [SerializeField] GameObject randomPostPrefab = default;

    CollectionHandler collectionHandler;
    ContentCollection collection;

    private void Awake() 
    {
        collectionHandler = FindObjectOfType<CollectionHandler>();
    }

    public void RefreshTimeline()
    {
        collection = collectionHandler.GetContentCollection();

        foreach (PostContent content in collection.contents)
        {
            if (content.storyIndex == collection.currentStoryIndex)
            {
                StartCoroutine(CreateNewPost(content));
            }
        }

        collection.IncrementStoryIndex();
    }
    
    private IEnumerator CreateNewPost(PostContent content)
    {
        if (content.type != PostType.Random)
        {
            InstantiatePost(postPrefab, content);
        }
        else
        {
            InstantiatePost(randomPostPrefab, content);
        }

        yield return new WaitForSeconds(delayBetweenNewPosts);
    }

    private void InstantiatePost(GameObject prefabToInstantiate, PostContent content)
    {
        GameObject newPost = Instantiate(prefabToInstantiate, transform.position, transform.rotation) as GameObject;
        newPost.transform.SetParent(this.transform, false);
        newPost.GetComponent<PostDisplay>().content = content;
    }
}
