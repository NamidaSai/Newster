using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Post Content", menuName = "Newster/New Content", order = 0)]
public class PostContent : ScriptableObject
{
    [Header("Characteristics")]
    [SerializeField] public string contentID = default;
    [SerializeField] public PostCategory category = default;
    [SerializeField] public int storyIndex = 1;
    [SerializeField] public PostType type = default;

    [Header("Details")]
    [SerializeField] public string profileText = null;
    [TextArea(4,14)] [SerializeField] public string headlineText = null;
    [SerializeField] public Sprite featureImage = null;
    [SerializeField] public string sourceText = null;
}
