using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterCustomizer : MonoBehaviour
{
    public enum Types
    {
        EARINGS,
        HATS,
        GLASSES,
        MOUSTACHES,
        COLLARS
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
            OnSetCustomize(p.type, p.partID);
    }
    void OnCustomize(Types type, int partID)
    {
        if (PlayerPrefs.GetInt(type.ToString(), 0) == partID)
            partID = -1;

        OnSetCustomize(type, partID);
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
