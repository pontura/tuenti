using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursoContentUI : MonoBehaviour
{
    public int id;
    DialoguesUI dialoguesUI;
    MultiplechoiceUI multiplechoiceUI;
    public DatabaseManager.AllContentData data;

    public GameObject[] characters;
    public GameObject mentor1;
    public GameObject mentor2;

    public GameObject client;

    public enum types
    {
        CURSO,
        VENTA
    }
    types type;

    private void Awake()
    {
        dialoguesUI = GetComponent<DialoguesUI>();
        multiplechoiceUI = GetComponent<MultiplechoiceUI>();
    }
    Vector3 clientPos;
    Vector3 conejoPos;
    public void Init(types type)
    {
        this.type = type;
        id = 0;
        if (type == types.CURSO)
        {
            int character_id = Data.Instance.databaseManager.GetCursoByID(Data.Instance.userData.curso_active_id).character_id;
            data = Data.Instance.databaseManager.GetCursoContentActive();
            if (character_id == 0)
            {
                mentor1.SetActive(true);
                mentor2.SetActive(false);
            } else
            {
                mentor2.SetActive(true);
                mentor1.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject go in characters)
                go.SetActive(true);
            data = Data.Instance.databaseManager.GetVentaContentActive();
            
        }
        if (characters.Length > 2)
            client = characters[Random.Range(1, 3)];
        else
            client = characters[1];

        if (clientPos == Vector3.zero)
            clientPos = client.transform.localPosition;
        if(conejoPos == Vector3.zero)
            conejoPos = characters[0].transform.localPosition;

        SetOn();
    }
    void SetOn()
    {
        multiplechoiceUI.Close();
        dialoguesUI.Close();
        if(id > data.all.Length-1)
        {
            if (type == types.CURSO)
                GetComponent<CursosUI>().CursoReady();
            return;
        }
        DatabaseManager.CursoContentLineData d = data.all[id];

        foreach (GameObject go in characters)
            go.transform.localPosition = new Vector3(1000, 0, 0);

        if (d.character_id == 1)
            client.transform.localPosition = clientPos;
        else
            characters[0].transform.localPosition = conejoPos;

        List<DatabaseManager.MultiplechoiceData> arr;

        if (type == types.CURSO)
            arr = Data.Instance.databaseManager.GetMultiplechoiceDataByCursoID(d.id);
        else
            arr = Data.Instance.databaseManager.GetMultiplechoiceDataByVentaID(d.id);

        print("Curso Content: character_id: " + d.character_id + "     d.isMultiplechoice: " + d.isMultiplechoice + "   arr: " + arr.Count + "  d.goto_id: " + d.goto_id);
        if (arr.Count < 2)
            d.isMultiplechoice = false;

        if (d.isMultiplechoice)
        {
            multiplechoiceUI.OnInit(d, type);

            if (type == types.VENTA)
            {
                
                int highscore = 0;
                foreach (DatabaseManager.MultiplechoiceData multipleData in arr)
                {
                    if (multipleData.correct > highscore)
                        highscore = multipleData.correct;
                }
                GetComponent<VentasUI>().totalScore += highscore;
            }
        }
        else
            dialoguesUI.OnInit(d, type);
    }
    public void Next()
    {
        id++;
        SetOn();
    }
    public void Goto(int goto_id, int correct)
    {
        if (type == types.VENTA)
            GetComponent<VentasUI>().score += correct;
        if(goto_id == 0)
        {
            if (type == types.VENTA)
            {
                bool success = false;
                if (correct > 0)
                    success = true;
                GetComponent<VentasUI>().OnReady(success);
                return;
            }
        }
        id = 0;
        foreach (DatabaseManager.CursoContentLineData d in data.all)
        {
            if(d.id == goto_id)
            {
                SetOn();
                return;
            } else
                id++;
        }
    }
}
