using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookButton : UIButton
{
    public Books.BookData data;
    public Image image;

    public void OnInit(Books.BookData data)
    {
        this.data = data;
        image.sprite = data.thumb;
    }
}
