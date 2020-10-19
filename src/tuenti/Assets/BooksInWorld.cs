using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksInWorld : MonoBehaviour
{
    public Book[] books;

    void Awake()
    {
        Events.AddBookToWorld += AddBookToWorld;
        foreach (Book book in books)
            book.gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        Events.AddBookToWorld -= AddBookToWorld;
    }
    public void AddBookToWorld(Books.BookData data)
    {
        books[data.containerID].Init(data);
    }
    
}
