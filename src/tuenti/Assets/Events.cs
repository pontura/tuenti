using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static System.Action OnGameOver = delegate { };
    public static System.Action DatabaseLoaded = delegate { };
    public static System.Action<int> ReadBook = delegate { };
    public static System.Action<Books.BookData> AddBookToWorld = delegate { };
    public static System.Action<Books.BookData> GetBook = delegate { };
}
