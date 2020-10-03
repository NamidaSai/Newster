using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentCollection
{
    public PostCategory category = default;
    public List<PostContent> contents = new List<PostContent>();
    public int currentStoryIndex = 1;

    public void IncrementStoryIndex()
    {
        currentStoryIndex++;
    }
}

public class CollectionHandler : MonoBehaviour
{
    [SerializeField] int maxStoryIndex = 4;
    [SerializeField] PostContent[] allContents = default;

    List<ContentCollection> allCollections = new List<ContentCollection>()
                                                {
                                                    new ContentCollection{ category = PostCategory.War },
                                                    new ContentCollection{ category = PostCategory.Virus },
                                                    new ContentCollection{ category = PostCategory.Elections },
                                                    new ContentCollection{ category = PostCategory.Referendum },
                                                };

    private void Start() 
    {
        DefineContentCollections();
    }

    public ContentCollection GetContentCollection()
    {
        int collectionIndex = Random.Range(0, allCollections.Count);

        if (allCollections.TrueForAll(IsFinished))
        {
            FindObjectOfType<CredibilityManager>().ModifyCredibility(-100f);
            return allCollections[collectionIndex];
        }

        while (IsFinished(allCollections[collectionIndex]))
        {
            collectionIndex = Random.Range(0, allCollections.Count);
        }
        
        return allCollections[collectionIndex];
    }

    private bool IsFinished(ContentCollection collection)
    {
        return collection.currentStoryIndex == maxStoryIndex;
    }

    private void DefineContentCollections()
    {
        foreach(PostContent content in allContents)
        {
            foreach(ContentCollection collection in allCollections)
            {
                if (content.category == collection.category)
                {
                    collection.contents.Add(content);
                }
            }
        }
    }
}