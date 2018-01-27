using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct GameJson
{
    public SceneJson[] scenes;
}

[System.Serializable]
public struct SceneJson
{
    public string id;
    public string[] conditions;
    public string script;
    public string fallback;
    public string text;
    public OptionObj[] options;
}

[System.Serializable]
public struct SceneObj
{
    public string[] conditions;
    public string text;
    public string script;
    public string fallback;
    public OptionObj[] options;
}

[System.Serializable]
public struct OptionObj
{
    public string text;
    public string link;
    public string flag;
}

[System.Serializable]
public struct WritingJson
{
    public TextJson[] writing;
}

[System.Serializable]
public struct TextJson
{
    public string name;
    public string text;
}