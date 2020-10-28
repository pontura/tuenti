using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursoContentUI : MonoBehaviour
{
    public int id;
    DialoguesUI dialoguesUI;
    MultiplechoiceUI multiplechoiceUI;
    public DatabaseManager.AllContentData data;

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
    public void Init(types type)
    {
        this.type = type;
        id = 0;
        if(type == types.CURSO)
            data = Data.Instance.databaseManager.GetCursoContentActive();
        else
            data = Data.Instance.databaseManager.GetVentaContentActive();
        SetOn();
    }
    void SetOn()
    {
        multiplechoiceUI.Close();
        dialoguesUI.Close();
        if(id > data.all.Length-1)
        {
            GetComponent<CursosUI>().CursoReady();
            return;
        }
        DatabaseManager.CursoContentLineData d = data.all[id];
        if (d.isMultiplechoice)
            multiplechoiceUI.OnInit(d, type);
        else
            dialoguesUI.OnInit(d);
    }
    public void Next()
    {
        id++;
        SetOn();
    }
    public void Goto(int goto_id)
    {
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
