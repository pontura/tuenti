using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    System.Action OnDone;
    public GameObject panel;

    void Start()
    {
        Events.PlayVideo += PlayVideo;
        videoPlayer.prepareCompleted += Prepared;
        panel.SetActive(false);
    }
    private void OnDestroy()
    {
        Events.PlayVideo -= PlayVideo;        
    }
    void PlayVideo(string url, System.Action OnDone)
    {
        panel.SetActive(true);
        this.OnDone = OnDone;
        GetComponent<YoutubeParser>().GetMp4Url(url, OnVideoDone);
    }
    void OnVideoDone(string url)
    {
        print("__________________OnVideoDone");
         videoPlayer.url = url;
         videoPlayer.Prepare();
    }    
    public void Close()
    {
        panel.SetActive(false);
        OnDone();
    }
    void Prepared(UnityEngine.Video.VideoPlayer vp) {
            videoPlayer.Play();
    }
}
