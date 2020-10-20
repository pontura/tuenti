﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBooks : UIScrollItemsScreen
{
    public Text booksField;

    private void Start()
    {
        SetBooksGrabbed();
        Events.GetBook += GetBook;
    }
    private void OnDestroy()
    {
        Events.GetBook -= GetBook;
    }
    void GetBook(Books.BookData d) { SetBooksGrabbed(); }
    public void OpenBooks()
    {
        Data.Instance.uiBooks.OnInit();
    }
    void SetBooksGrabbed()
    {
        int totalBooksGrabbed = Data.Instance.userData.GetTotalBooksGrabbed();
        booksField.text = "Libros (" + totalBooksGrabbed + ")";
    }
    public void OnInit()
    {
        Init();
        Reset();
        foreach (Books.BookData data in GetComponent<Books>().all)
        {
            BookButton newButton = (BookButton)AddItem();
            newButton.OnInit(data);
        }
    }
    public override void OnUIButtonClicked(UIButton uiButton) {

        BookButton button = (BookButton)uiButton;
        Events.ReadBook(button.data.id);
        Close();
    }
}