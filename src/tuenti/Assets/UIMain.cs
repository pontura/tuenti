using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
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
    void GetBook(Books.BookData d)  { SetBooksGrabbed(); }
    public void OpenBooks()
    {
        Data.Instance.uiBooks.OnInit();
    }
    void SetBooksGrabbed()
    {
        int totalBooksGrabbed = Data.Instance.userData.GetTotalBooksGrabbed();
        booksField.text = "Libros (" + totalBooksGrabbed + ")";
    }
}
