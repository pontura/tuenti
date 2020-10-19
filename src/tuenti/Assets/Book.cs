using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public SpriteRenderer sr;
    Books.BookData data;

    public void Init(Books.BookData data)
    {
        this.data = data;
        sr.sprite = data.thumb;
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            Events.GetBook(data);
        }
    }
}
