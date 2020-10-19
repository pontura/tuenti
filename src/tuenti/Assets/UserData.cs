using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public int curso_active_id;
    public int level;
    int totalBooks = 6;
    public List<int> books;

    private void Awake()
    {
        Events.GetBook += GetBook;
    }
    private void OnDestroy()
    {
        Events.GetBook -= GetBook;
    }
    void Start()
    {
        for(int a=0; a< totalBooks; a++)
            books.Add(PlayerPrefs.GetInt("book_" + a, 0));

        GetComponent<Books>().Init(books);
    }
    void GetBook(Books.BookData data)
    {
        int id = data.id;
        books[id] = 1;
        PlayerPrefs.SetInt("book_" + id, 1);
    }
    public int GetTotalBooksGrabbed()
    {
        int total = 0;
        foreach (int num in books)
            if (num == 1)
                total++;
        return total;
    }
}
