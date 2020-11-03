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
    public VentasData ventasData;

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
    [Serializable]
    public class VentasData
    {
        public int lastPlayedID;
        public VentaData[] all;
    }
   
    [Serializable] public class CursoData
    {
        public int id;
        public string nombre;
        public AllContentData allContent;
        public int test_score;
        public int character_id;

        public void CheckIfScore()
        {
            test_score = PlayerPrefs.GetInt("test_curso_" + id, 0);
        }
        public void SetScore(int score)
        {
            if (test_score > score)
                return;
            test_score = score;
            PlayerPrefs.SetInt("test_curso_" + id, score);
        }
    }
    [Serializable] public class CursoContentLineData
    {
        public int id;
        public int curso_id;
        public int venta_id;
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
        public int ventaContent_id;
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
        public types type;
        public enum types
        {
            SINGLE,
            MULTIPLE
        }
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
    [Serializable]
    public class VentaData
    {
        public int id;
        public string nombre;
        public AllContentData allContent;
    }

    public void Init()
    {
        StartCoroutine( LoadJson(url + "getCursos.php", OnCursosDone) );
    }
    void OnCursosDone(string data)
    {
        cursosData = JsonUtility.FromJson<CursosData>(data);
        foreach (CursoData cursoData in cursosData.all)
            cursoData.CheckIfScore();
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
        StartCoroutine(LoadJsonCursosContent(GetVentas));
    }
    void GetVentas()
    {
        StartCoroutine(LoadJson(url + "getVentas.php", GetVentasDone));
    }
    void GetVentasDone(string data)
    {
        ventasData = JsonUtility.FromJson<VentasData>(data);
        StartCoroutine(LoadJsonVentaContent(AllLoaded));
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
    IEnumerator LoadJsonVentaContent(System.Action OnDone)
    {
        foreach (VentaData cData in ventasData.all)
        {
            string newURL = url + "getVentaContent.php?id=" + cData.id;
            print(newURL);
            

            WWW www = new WWW(newURL);
            yield return www;
            if (www.error == null)
            {             
                cData.allContent = JsonUtility.FromJson<AllContentData>(www.text);
                foreach (CursoContentLineData d in cData.allContent.all)
                    d.isMultiplechoice = true;
            }
            else
            {
                Debug.Log("ERROR: " + www.error);
            }
        }
        OnDone();
    }
    public CursoData GetCursoByID(int id)
    {
        foreach (CursoData c in cursosData.all)
            if (c.id == id)
                return c;
        return null;
    }
    public AllContentData GetCursoContentActive()
    {
        return GetCursoContent(Data.Instance.userData.curso_active_id);
    }
    public AllContentData GetVentaContentActive()
    {
        print("Data.Instance.userData.venta_active_id " + Data.Instance.userData.venta_active_id);
        AllContentData d = GetVentaContent(ventasData.all[Data.Instance.userData.venta_active_id].id);
        return d;
    }
    public AllContentData GetCursoContent(int id)
    {
        foreach (CursoData c in cursosData.all)
            if (c.id == id)
                return c.allContent;
        return null;
    }
    public AllContentData GetVentaContent(int id)
    {
        foreach (VentaData c in ventasData.all)
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
    public List<MultiplechoiceData> GetMultiplechoiceDataByVentaID(int venta_id)
    {
        List<MultiplechoiceData> all = new List<MultiplechoiceData>();
        foreach (MultiplechoiceData data in multiplechoiceData.all)
            if (data.ventaContent_id == venta_id)
                all.Add(data);
        return all;
    }
    public List<AnswerData> GetTriviaByTest(int test_id)
    {
        List<AnswerData> all = new List<AnswerData>();
        foreach (AnswerData data in answwersData.all)
            if (data.test_id == test_id)
                all.Add(data);
        return all;
    }
    public List<TestData> GetAllTestDataByCurso(int id)
    {
        List<TestData> arr = new List<TestData>();
        foreach (TestData data in testsData.all)
            if (data.curso_id == id)
                arr.Add(data);
        return arr;
    }
    public int GetTotalStars()
    {
        int total = 0;
        foreach (CursoData c in cursosData.all)
            total += c.test_score;
        return total;
    }
    public bool IsCursoLocked(int curso_id)
    {
        int id = 0;
        int level = Data.Instance.userData.level;
        foreach (CursoData c in cursosData.all)
        {
            if (c.id == curso_id)
            {
                if (level == 0)
                {
                    if (id == 0) return false; else return true;
                }
                else if (level == 1)
                {
                    if (id < 4) return false; else return true;
                }
            }
            id++;
        }
        return true;
    }
}
