using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Books : MonoBehaviour
{
    public BookData[] all;
    
    [Serializable]
    public class BookData
    {
        public int id;
        public int level;
        public int containerID;
        public states state;
        public Sprite thumb;
        public enum states
        {
            BLOCKED,
            SHOW,
            GOT_IT
        }
    }
    private void Start()
    {
        Events.GetBook += GetBook;
    }
    private void OnDestroy()
    {
        Events.GetBook -= GetBook;
    }
    public void Init(List<int> arr)
    {        
        int id = 0;
        foreach (BookData bookData in all)
        {
            if (arr[id] == 1)
                bookData.state = BookData.states.GOT_IT;
            id++;
        }
    }
    public void CheckToAddBookToScene()
    {
        int level = Data.Instance.userData.level;
        foreach (BookData data in all)
        {
            print(data.state + "data.lelve_: " + data.level + " leve:" + level);
            if (data.level == level && data.state != BookData.states.GOT_IT)
                Events.AddBookToWorld(data);
        }
    }
    void GetBook(BookData data)
    {
        foreach (BookData bd in all)
            if (bd.id == data.id)
                bd.state = BookData.states.GOT_IT;
    }
}
