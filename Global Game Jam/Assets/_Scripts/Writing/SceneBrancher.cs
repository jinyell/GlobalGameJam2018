using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GlobalGameJam
{
    public class SceneBrancher : MonoBehaviour
    {

        public string SceneID;
        public SceneObj currentScene;
        public Dictionary<string, SceneObj> scenes;
        public Dictionary<string, string> writing;
        public Dictionary<string, bool> flags;

        public PressButton[] buttons;

        public TextMeshPro text;

        JsonReader jr;
        ScriptManager sm;

        void Start()
        {
            flags = new Dictionary<string, bool>();
            jr = GetComponent<JsonReader>();
            sm = GetComponent<ScriptManager>();
            jr.Init();
            displayScene(currentScene);
        }

        public void displayScene(SceneObj scene)
        {
            //If the flags aren't set, switch to fallback scene
            if (checkCondition(scene) == false)
            {
                if (scene.fallback == null)
                    Debug.LogError("NO FALLBACK FROUND FOR SCENE " + SceneID);
                ChangeScene(scene.fallback);
                return;
            }

            //Run run scene script
            if (scene.script != null)
            {
                if (sm != null)
                    sm.SendMessage(scene.script);
            }

            if(scene.end)
            {
                return;
            }

            //set the current scene and display options
            currentScene = scene;
            text.text = getWriting(scene.text);

            int optionsCount;
            if (scene.options == null)
                optionsCount = 0;
            else
                optionsCount = scene.options.Length;

            for (int i = 0; i < 3; ++i)
            {
                GameObject obj = buttons[i].gameObject;

                //Only shows buttons up to optionsCount
                obj.SetActive(i < optionsCount);
                if (i < optionsCount)
                {
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = getWriting(scene.options[i].text);
                }
            }
        }

        public string getWriting(string id)
        {
            print(id);
            if (writing.ContainsKey(id) == false)
                Debug.LogError("NO WRITING FOUND WITH ID " + id);
            return writing[id];
        }

        public bool checkCondition(SceneObj scene)
        {
            if (scene.conditions == null)
                return true;

            bool ret;
            foreach (string flag in scene.conditions)
            {
                if (flags.TryGetValue(flag, out ret) == false)
                    return false;
            }
            return true;
        }

        public void ChangeScene(string SceneName)
        {
            if (scenes.ContainsKey(SceneName) == false)
                Debug.LogError("SCENE DOES NOT EXIST: " + SceneName + " FROM SCENE " + SceneID);

            SceneID = SceneName;
            displayScene(scenes[SceneName]);
        }

        public void ChangeScene(int OptionNumber)
        {
            if (OptionNumber >= currentScene.options.Length)
                Debug.LogError("OPTION NUMBER " + OptionNumber + " IS NOT VALID IN SCENE " + SceneID);

            OptionObj option = currentScene.options[OptionNumber];
            if (option.flag != null)
                flags.Add(option.flag, true);

            if (scenes.ContainsKey(option.link) == false)
                Debug.LogError("INVALID SCENE NAME " + option.link + " CONNECTING FROM OPTION #" + OptionNumber + " IN SCENE " + SceneID);

            SceneID = option.link;
            displayScene(scenes[option.link]);
        }
    }
}