using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Events
{
    public static System.Action<string, System.Action> PlayVideo = delegate { };
    public static System.Action<bool> OnVideoError = delegate { };
    public static System.Action OnGameOver = delegate { };
    public static System.Action DatabaseLoaded = delegate { };
    public static System.Action<int> ReadBook = delegate { };
    public static System.Action<Books.BookData> AddBookToWorld = delegate { };
    public static System.Action<Books.BookData> GetBook = delegate { };
    public static System.Action<string, System.Action> OnConfirmation = delegate { };
    public static System.Action<string, Sprite, System.Action> OnConfirmationImage = delegate { };
    public static System.Action<string, string, bool> PlaySound = delegate { };
    public static System.Action<string, float> ChangeVolume = delegate { };
    public static System.Action<CharacterCustomizer.Types, int> OnCustomize = delegate { };
}
