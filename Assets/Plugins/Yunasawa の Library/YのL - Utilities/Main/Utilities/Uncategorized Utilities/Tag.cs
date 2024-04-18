using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tag : MonoBehaviour
{
    public string[] Tags = new string[0];

    public bool HasTag(string tag) => Tags.Contains(tag);
    public bool HasAllTags(params string[] tags)
    {
        foreach (string tag in tags) if (!Tags.Contains(tag)) return false;
        return true;
    }
    public bool HasOneTag(params string[] tags)
    {
        foreach (string tag in tags) if (Tags.Contains(tag)) return true;
        return false;
    }
    public void AddTag(params string[] tags)
    {
        List<string> tagList = Tags.ToList();
        foreach (var tag in tags) if (!HasTag(tag)) tagList.Add(tag);
        Tags = tagList.ToArray();
    }
    public void RemoveTag(params string[] tags)
    {
        List<string> tagList = Tags.ToList();
        foreach (var tag in tags) if (HasTag(tag)) tagList.Remove(tag);
        Tags = tagList.ToArray();
    }
}

public static class TagUtilities
{
    /// <summary>
    /// Check if a GameObject has Tag component and contains correct tags.
    /// </summary>
    public static bool HasTag(this GameObject gameObject, string tag)
        => gameObject.TryGetComponent<Tag>(out var tags) && tags.HasTag(tag);

    /// <summary>
    /// Check if a GameObject has Tag component and contains all the tags given.
    /// </summary>
    public static bool HasAllTags(this GameObject gameObject, params string[] tags)
        => gameObject.TryGetComponent<Tag>(out var tag) && tag.HasAllTags(tags);

    /// <summary>
    /// Check if a GameObject has Tag component and contains one out of all he tags given.
    /// </summary>
    public static bool HasOneTag(this GameObject gameObject, params string[] tags)
        => gameObject.TryGetComponent<Tag>(out var tag) && tag.HasOneTag(tags);
}