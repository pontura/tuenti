using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextsManager : MonoBehaviour
{
    public Data texts;
    [Serializable]
    public class Data
    {
        public DataContent all;
    }
    [Serializable]
    public class DataContent
    {
        public string door_to_academy;
        public string door_to_city;
        public string door_to_home;
    }
    void Start()
    {
        TextAsset t = Resources.Load<TextAsset>("texts");
        texts = JsonUtility.FromJson<Data>(t.text);
    }
}
