using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class JsonReader : MonoBehaviour
    {

        public TextAsset Game;
        public TextAsset Language;

        SceneBrancher sb;

        public void Init()
        {
            sb = GetComponent<SceneBrancher>();
            if (sb.scenes == null)
                sb.scenes = new Dictionary<string, SceneObj>();

            if (sb.writing == null)
                sb.writing = new Dictionary<string, string>();

            GameJson game = JsonUtility.FromJson<GameJson>(Game.ToString());
            parseGame(game);

            WritingJson language = JsonUtility.FromJson<WritingJson>(Language.ToString());
            parseLanguage(language);
        }

        void parseLanguage(WritingJson language)
        {
            foreach (TextJson text in language.writing)
            {
                if (sb.writing.ContainsKey(text.name))
                    sb.writing[text.name] = text.text;
                else
                    sb.writing.Add(text.name, text.text);
            }
                
        }

        void parseGame(GameJson game)
        {
            foreach (SceneJson scene in game.scenes)
            {
                if (sb.scenes.ContainsKey(scene.id))
                    sb.scenes[scene.id] = jsonToScene(scene);
                else
                    sb.scenes.Add(scene.id, jsonToScene(scene));
            }
            sb.currentScene = jsonToScene(game.scenes[0]);
            sb.SceneID = game.scenes[0].id;
        }

        private SceneObj jsonToScene(SceneJson scene)
        {
            SceneObj obj = new SceneObj();

            obj.conditions = scene.conditions;
            obj.fallback = scene.fallback;
            obj.script = scene.script;
            obj.text = scene.text;
            obj.options = scene.options;
            obj.end = scene.end;

            return obj;
        }
    }
}