using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CharacterCustomizer : MonoBehaviour
{
    public enum Types
    {
        EARINGS,
        HATS,
        GLASSES,
        MOUSTACHES,
        COLLARS,
        COLOR_REMES,
        COLOR_PANTAS,
        COLOR_ZAPAS
    }
    [Serializable]
    public class Parts
    {
        public Types type;
        public int partID = -1;
        public GameObject[] all;
    }
    public Parts[] parts;


    void Start()
    {
        Events.OnCustomize += OnCustomize;
    }
    void OnDestroy()
    {
        Events.OnCustomize -= OnCustomize;
    }
    private void OnEnable()
    {
        string[] PieceTypeNames = System.Enum.GetNames(typeof(Types));
        for (int i = 0; i < PieceTypeNames.Length; i++)
        {
            string typeName = PieceTypeNames[i];
            int partID = PlayerPrefs.GetInt(typeName, -1);
            Types t = (Types)i;
            Parts p = GetPart(t);
            if(p!= null)
                p.partID = partID;
        }
        foreach (Parts p in parts)
        {
            if (p.type == Types.COLOR_PANTAS || p.type == Types.COLOR_REMES || p.type == Types.COLOR_ZAPAS)
            {
                p.partID = PlayerPrefs.GetInt(p.type.ToString());
                Colorize(p.type, false);
            }                
            else
                OnSetCustomize(p.type, p.partID);
        }
    }
    void OnCustomize(Types type, int partID)
    {
        if (type == Types.COLOR_PANTAS || type == Types.COLOR_REMES || type == Types.COLOR_ZAPAS)
        {
            Colorize(type, true);
            return;
        }
        if (PlayerPrefs.GetInt(type.ToString(), 0) == partID)
            partID = -1;

        OnSetCustomize(type, partID);
    }
    void Colorize(Types type, bool setNext)
    {
        foreach (GameObject go in GetPart(type).all)
            go.GetComponent<Image>().color = GetColorFor(type, setNext);  
    }
    Color GetColorFor(Types type, bool setNext)
    {
        switch (type)
        {
            case Types.COLOR_REMES:     return SetNextColorTo(type, Data.Instance.settings.remerasColor, setNext);
            case Types.COLOR_PANTAS:    return SetNextColorTo(type, Data.Instance.settings.pantalonesColor, setNext);
            default:                    return SetNextColorTo(type, Data.Instance.settings.zapasColor, setNext);
        }
    }
    Color SetNextColorTo(Types type, Color[] arr, bool setNext)
    {
        Parts parts = GetPart(type);
        int a = parts.partID;
        if (setNext)
        {
            a++;
            if (a >= arr.Length)
                a = 0;

            print("SetNextColorTo: " + type + " " + a);

            parts.partID = a;
            PlayerPrefs.SetInt(type.ToString(), a);
        }
        return arr[a];
    }
    void OnSetCustomize(Types type, int partID)
    {       
        PlayerPrefs.SetInt(type.ToString(), partID);
        SetCustomize(type, partID);
    }
    void SetCustomize(Types type, int partID)
    {
        Parts parts = GetPart(type);
        int id = 0;
        foreach (GameObject go in parts.all)
        {
            if (id == partID)
                go.SetActive(true);
            else
                go.SetActive(false);
            id++;
        }
    }
    Parts GetPart(Types type)
    {
        foreach (Parts p in parts)
            if (p.type == type)
                return p;
        return null;
    }
}
