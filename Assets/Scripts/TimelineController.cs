using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimelineController : MonoBehaviour
{
    [SerializeField] GameObject postPrefab = default;
    [SerializeField] GameObject randomPostPrefab = default;
    [SerializeField] GameObject oldNewtsPrefab = default;

    CollectionHandler collectionHandler;
    ContentCollection collection;

    private void Awake() 
    {
        collectionHandler = FindObjectOfType<CollectionHandler>();
    }

    public void RefreshTimeline()
    {
        PostContent oldNewtsContent = oldNewtsPrefab.GetComponent<PostDisplay>().content;
        StartCoroutine(CreateNewPost(oldNewtsContent));

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
        if (content.type == PostType.Fake || content.type == PostType.News)
        {
            InstantiatePost(postPrefab, content);
        }
        else if (content.type == PostType.Random)
        {
            InstantiatePost(randomPostPrefab, content);
        }
        else
        {
            InstantiatePost(oldNewtsPrefab, content);
        }

        yield return new WaitForSeconds(0.01f);
        LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
    }

    private void InstantiatePost(GameObject prefabToInstantiate, PostContent content)
    {
        GameObject newPost = Instantiate(prefabToInstantiate, transform.position, transform.rotation) as GameObject;
        newPost.transform.SetParent(this.transform, false);
        newPost.GetComponent<PostDisplay>().content = content;
    }
}
