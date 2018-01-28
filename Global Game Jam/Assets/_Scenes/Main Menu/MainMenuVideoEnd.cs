using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MainMenuVideoEnd : MonoBehaviour {

    public GameObject[] toActivate;
    public GameObject videoPlayerScreen;
    VideoPlayer vp;
    bool skip = false;

	void Awake () {
        vp = GetComponent<VideoPlayer>();
        StartCoroutine(runWhenFinished());
	}

    IEnumerator runWhenFinished()
    {
        while (vp.isPlaying == false)
            yield return 0;

        while(vp.isPlaying && skip == false)
            yield return 0;

        vp.enabled = false;
        if(videoPlayerScreen != null) {
            videoPlayerScreen.SetActive(false);
        }
        
        foreach (GameObject obj in toActivate)
        {
            obj.SetActive(true);
        }
    }

    void Update()
    {
        if(Input.anyKeyDown)
            skip = true;
    }
}
