using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookReader : UIPanelScreen
{
    private void Awake()
    {
        Events.ReadBook += ReadBook;
    }
    private void OnDestroy()
    {
        Events.ReadBook -= ReadBook;
    }
    public void ReadBook(int id)
    {
        Init();
    }
}
