using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour {

    public TextAsset Game;
    public TextAsset Language;

    static public SceneObj currentScene;
    static public Dictionary<string, SceneObj> scenes;
    static public Dictionary<string, string> writing;
    
	void Start ()
    {
        if(scenes != null)
            scenes = new Dictionary<string, SceneObj>();

        if (writing != null)
            writing = new Dictionary<string, string>();

        GameJson game = JsonUtility.FromJson<GameJson>(Game.ToString());
        parseGame(game);
        print(game.scenes[1].text);
    }
	
	void parseGame(GameJson game)
    {
        foreach(SceneJson scene in game.scenes)
        {
            scenes.Add(scene.id, jsonToScene(scene));
        }
        currentScene = jsonToScene(game.scenes[0]);
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

/*
{
	"scenes":
	[
		{
			"id":"BEGIN",
			"text":"This is the Start",
			"options":
			[
				{
					"text":"Yes",
					"link":"GOOD",
					"flag":"SAID_YES"
				},
				{
					"text":"No",
					"link":"BAD"
				},
				{
					"text":"Rude",
					"link":"BAD",
					"flag":"RUDE"
				}
			]
		},
		{
			"id":"GOOD",
			"text":"I'm glad you agree!",
			"options":
			[
				{
					"text":"Continue",
					"link":"END"
				}
			]
		},
		{
			"id":"BAD",
			"text":"How dare you!",
			"options":
			[
				{
					"text":"Continue",
					"link":"END"
				}
			]
		},
		{
			"id":"END",
			"text":"Hold on...",
			"options":
			[
				{
					"text":"Continue",
					"link":"END_GOOD"
				}
			]
		},
		{
			"id":"END_GOOD",
			"conditions":["SAID_YES"],
			"fallback":"END_RUDE",
			"Script":"TestScript",
			"text":"You were nice",
		},
		{
			"id":"END_RUDE",
			"conditions":["RUDE"],
			"fallback":"END_FINAL",
			"text":"you were rude",
		},
		{
			"id":"END_FINAL",
			"text":"I don't care"
		}
	]
}

*/