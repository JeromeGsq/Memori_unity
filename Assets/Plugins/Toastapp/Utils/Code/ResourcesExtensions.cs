using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourcesExtensions  {
    public static string LoadResourceTextfile(string path)
    {
        string filePath = path.Replace(".json", "");
        Debug.Log(filePath);
        TextAsset targetFile = Resources.Load<TextAsset>(filePath);
        return targetFile.text;
    }
}
