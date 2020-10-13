using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DatabaseManager : MonoBehaviour
{
    string url = "http://www.pontura.com/tuenti/";

    public CursosData cursosData;
    public MultiplechoicesData multiplechoiceData;

    [Serializable] public class CursosData  {
        public CursoData[] all;
    }
    [Serializable] public class AllContentData
    {
        public CursoContentLineData[] all;
    }
    [Serializable]
    public class MultiplechoicesData
    {
        public MultiplechoiceData[] all;
    }
    [Serializable] public class CursoData
    {
        public int id;
        public string nombre;
        public AllContentData allContent;
    }
    [Serializable] public class CursoContentLineData
    {
        public int id;
        public int curso_id;
        public int character_id;
        public string text;
        public int order;
        public int correct;
        public int goto_id;
        public bool isMultiplechoice;
    }
    [Serializable]
    public class MultiplechoiceData
    {
        public int id;
        public int curso_id;
        public int character_id;
        public string text;
        public int order;
        public int correct;
        public int goto_id;
        public bool isMultiplechoice;
    }


    void Start()
    {
        StartCoroutine( LoadJson(url + "getCursos.php", OnCursosDone) );
    }
    void OnCursosDone(string data)
    {
        cursosData = JsonUtility.FromJson<CursosData>(data);
        StartCoroutine(LoadJsonCursosContent(GetCursosContentDone) );
    }
    void GetCursosContentDone()
    {
        StartCoroutine(LoadJson(url + "getMultiplechoice.php", OnMultiplechoiceDone));
    }
    void OnMultiplechoiceDone(string data)
    {
        multiplechoiceData = JsonUtility.FromJson<MultiplechoicesData>(data);
        StartCoroutine(LoadJsonCursosContent(GetCursosContentDone));
    }
    IEnumerator LoadJson(string url, System.Action<string> OnDone)
    {
        print(url);
       
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            OnDone(www.text);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }
    IEnumerator LoadJsonCursosContent(System.Action OnDone)
    {
        foreach (CursoData cData in cursosData.all)
        {
            string newURL = url + "getCursosContent.php?id=" + cData.id;
            print(newURL);

            WWW www = new WWW(newURL);
            yield return www;
            if (www.error == null)
            {
                print(www.text);
                cData.allContent = JsonUtility.FromJson<AllContentData>(www.text);
            }
            else
            {
                Debug.Log("ERROR: " + www.error);
            }
        }
        OnDone();
    }
}
