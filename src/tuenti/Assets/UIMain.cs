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
    public void Cursos()
    {
        Data.Instance.LoadLevel("Cursos");
    }
    public void ReadBook(int id)
    {
        Events.ReadBook(id);
    }
    void GetBook(Books.BookData d)  { SetBooksGrabbed(); }

    void SetBooksGrabbed()
    {
        int totalBooksGrabbed = Data.Instance.userData.GetTotalBooksGrabbed();
        booksField.text = "Libros (" + totalBooksGrabbed + ")";
    }
}
