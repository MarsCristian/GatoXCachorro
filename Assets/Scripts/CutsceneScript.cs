using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutsceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer video;
    public string nextSceneName;

    private float timeSinceStart;

    private void Start()
    {
        timeSinceStart = 0;
        video.playOnAwake = true;
        video.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStart += Time.deltaTime;
        if ((!video.isPlaying || Input.anyKeyDown) && timeSinceStart > 0.5f)
        {
            //Mudar a cena
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
