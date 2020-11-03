using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using SimpleJSON;

public class YoutubeParser : MonoBehaviour
{
    public string videoId;
    Dictionary<string, string> videoInfo;
    List<Dictionary<string, string>> urls;
    public string url;
    System.Action<string> OnDone;


    void Start() {
     
    }

    public void GetMp4Url(string vId, System.Action<string> callback) {
        videoId = vId;
        GetMp4Url(callback);
    }

    public void GetMp4Url(System.Action<string> callback) {
        StartCoroutine(GetRequest("https://www.youtube.com/get_video_info?html5=1&video_id=" + videoId));
        OnDone = callback;
    }

    IEnumerator GetRequest(string uri) {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri)) {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError) {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
                Events.OnVideoError(true);
            } else {
                //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                byte[] results = webRequest.downloadHandler.data;                
                //Debug.Log(results.Length);
                //Debug.Log(System.Text.Encoding.ASCII.GetString(results));
                videoInfo = qsToJson(System.Text.Encoding.ASCII.GetString(results));
                /*foreach (KeyValuePair<string, string> key in videoInfo)
                    Debug.Log(key.Key + " : " + key.Value);*/

                

                if (videoInfo.ContainsKey("url_encoded_fmt_stream_map")){
                    string[] tmp = videoInfo["url_encoded_fmt_stream_map"].Split(',');
                    urls = new List<Dictionary<string, string>>();
                    for (int i=0; i< tmp.Length; i++) {
                        urls.Add(qsToJson(tmp[i]));
                    }

                    Dictionary<string,string> mp4Url = urls.Find(v => v["type"].StartsWith("video/mp4"));
                    if (mp4Url != null) {
                        url = mp4Url["url"];
                        OnDone(url);
                    }
                } else if (videoInfo.ContainsKey("player_response")) {
                    var N = JSON.Parse(videoInfo["player_response"]);
                    Dictionary<int, string> sizedUrls = new Dictionary<int, string>();
                    var formats = N["streamingData"]["formats"];
                    foreach(JSONNode node in formats) {
                        string type = node["mimeType"];
                        if (type.Contains("mp4")) {
                            sizedUrls.Add(node["width"], node["url"]);
                        }
                    }
                    var urlsKeys = sizedUrls.Keys.ToList();
                    urlsKeys.Sort();
                    OnDone(sizedUrls[urlsKeys[0]]);
                } else {
                    Events.OnVideoError(true);
                }
            }
        }
    }

    Dictionary<string,string> qsToJson(string qs) {
        Dictionary<string, string> res = new Dictionary<string, string>();
        string[] pars = qs.Split('&');
        foreach (string s in pars) {
            string[] kv = s.Split('=');
            string k = kv[0];
            string v = kv[1];
            res.Add(k, WWW.UnEscapeURL(v));
            //Debug.Log(k + ": " + WWW.UnEscapeURL(v));
        }
        return res;
    }    
}
