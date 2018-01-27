using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour {

    public TextAsset Game;
    public TextAsset Language;

    SceneBrancher sb;

	public void Init ()
    {
        sb = GetComponent<SceneBrancher>();
        if(sb.scenes == null)
            sb.scenes = new Dictionary<string, SceneObj>();

        if (sb.writing == null)
            sb.writing = new Dictionary<string, string>();

        GameJson game = JsonUtility.FromJson<GameJson>(Game.ToString());
        parseGame(game);
        print(sb.scenes["BAD"].text);
    }
	
	void parseGame(GameJson game)
    {
        foreach(SceneJson scene in game.scenes)
        {
            sb.scenes.Add(scene.id, jsonToScene(scene));
        }
        sb.currentScene = jsonToScene(game.scenes[0]);
    }

    private SceneObj jsonToScene(SceneJson scene)
    {
        SceneObj obj = new SceneObj();

        obj.conditions = scene.conditions;
        obj.fallback = scene.fallback;
        obj.script = scene.script;
        obj.text = scene.text;
        obj.options = scene.options;

        return obj;
    }
}