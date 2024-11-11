using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ExercisePanel : MonoBehaviour
{
    public List<VideoClip> allClips;
    public Button next, previous, play, pause, restart;
    public TMP_Text titleText;
    public VideoPlayer player;
    int videoIndex = 0;

    private void OnEnable()
    {        
        next.onClick.AddListener(OnNext);
        previous.onClick.AddListener(OnPrevious);
        play.onClick.AddListener(OnPlay);
        pause.onClick.AddListener(OnPause);
        restart.onClick.AddListener(OnRestart);

        player.clip = allClips[0];

        OnPlay();
        OnPause();
    }

    private void OnDisable()
    {
        next.onClick.RemoveAllListeners();
        previous.onClick.RemoveAllListeners();
        play.onClick.RemoveAllListeners();
        pause.onClick.RemoveAllListeners();
        restart.onClick.RemoveAllListeners();
    }

    private void OnNext()
    {
        videoIndex++;

        if(videoIndex >= allClips.Count - 1)
            next.gameObject.SetActive(false);

        previous.gameObject.SetActive(true);
        titleText.text = "Exercise (" + (videoIndex + 1) + "/" + allClips.Count + ")";

        player.clip = allClips[videoIndex];

        OnPlay();
        OnPause();
    }

    private void OnPrevious()
    {
        videoIndex--;

        if(videoIndex <= 0)
            previous.gameObject.SetActive(false);

        next.gameObject.SetActive(true);
        titleText.text = "Exercise (" + (videoIndex + 1) + "/" + allClips.Count + ")";

        player.clip = allClips[videoIndex];

        OnPlay();
        OnPause();
    }

    private void OnPlay()
    {
        if(!player.isPlaying)
            player.Play();

        pause.gameObject.SetActive(true);
        play.gameObject.SetActive(false);
    }

    private void OnPause()
    {
        player.Pause();
        pause.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
    }

    private void OnRestart()
    {
        player.Stop();
        player.Play();
    }
}
