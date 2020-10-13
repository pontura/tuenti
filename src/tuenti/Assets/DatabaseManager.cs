using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DatabaseManager : MonoBehaviour
{
    string url = "http://www.pontura.com/tuenti/";
    public bool allLoaded;
    public CursosData cursosData;
    public MultiplechoicesData multiplechoiceData;
    public TestsData testsData;
    public AnswersData answwersData;

    [Serializable] public class CursosData  {
        public CursoData[] all;
    }
    [Serializable] public class AllContentData
    {
        public CursoContentLineData[] all;
    }
    [Serializable] public class TestsData
    {
        public TestData[] all;
    }
    [Serializable] public class AnswersData
    {
        public AnswerData[] all;
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
        public int cursoContent_id;
        public int character_id;
        public string text;
        public int order;
        public int correct;
        public int goto_id;
        public bool isMultiplechoice;
    }
    [Serializable]
    public class TestData
    {
        public int id;
        public int curso_id;
        public string text;
        public int order;
    }
    [Serializable]
    public class AnswerData
    {
        public int id;
        public int test_id;
        public int value;
        public string text;
        public int order;
    }

    public void Init()
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
        StartCoroutine(LoadJsonCursosContent(GetTests));
    }
    void GetTests()
    {
        StartCoroutine(LoadJson(url + "getTests.php", GetTestsDone));
    }
    void GetTestsDone(string data)
    {
        testsData = JsonUtility.FromJson<TestsData>(data);
        StartCoroutine(LoadJsonCursosContent(GetAnswers));
    }
    void GetAnswers()
    {
        StartCoroutine(LoadJson(url + "getAnswers.php", GetAnswersDone));
    }
    void GetAnswersDone(string data)
    {
        answwersData = JsonUtility.FromJson<AnswersData>(data);
        StartCoroutine(LoadJsonCursosContent(AllLoaded));
    }
    void AllLoaded()
    {
        Events.DatabaseLoaded();
        allLoaded = true;
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

                cData.allContent = JsonUtility.FromJson<AllContentData>(www.text);
            }
            else
            {
                Debug.Log("ERROR: " + www.error);
            }
        }
        OnDone();
    }
    public AllContentData GetCursoContentActive()
    {
        return GetCursoContent(Data.Instance.userData.curso_active_id);
    }
    public AllContentData GetCursoContent(int id)
    {
        foreach (CursoData c in cursosData.all)
            if (c.id == id)
                return c.allContent;
        return null;
    }
    public List<MultiplechoiceData> GetMultiplechoiceDataByCursoID(int curso_id)
    {
        List<MultiplechoiceData> all = new List<MultiplechoiceData>();
        foreach (MultiplechoiceData data in multiplechoiceData.all)
            if (data.cursoContent_id == curso_id)
                all.Add(data);
        return all;
    }
}
