using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public string[] levels;
    public string username;
    public int curso_active_id;
    public int venta_active_id;
    public int level;
    public int curso_id;
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

        username = PlayerPrefs.GetString("username");
        level = PlayerPrefs.GetInt("level", 0);
        curso_id = PlayerPrefs.GetInt("curso_id", 0);


        GetComponent<Books>().Init(books);
    }
    public bool IsLogged()
    {
        if (username == "")
            return false;
        return true;
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
    public void CursoDone()
    {
        if (curso_id < curso_active_id)
        {
            curso_id = curso_active_id;
            PlayerPrefs.SetInt("curso_id", curso_id);           
        }
    }
    public void NextVenta()
    {
        venta_active_id++;
        if (venta_active_id >= Data.Instance.databaseManager.ventasData.all.Length)
            venta_active_id = 0;
        PlayerPrefs.SetInt("venta_active_id", venta_active_id);
    }
    public void Register(string _username)
    {
        PlayerPrefs.SetString("username", _username);
        username = _username;
    }
    public void SetLevelUp()
    {
        level++;
        PlayerPrefs.SetInt("level", level);
        Events.OnConfirmation("Subiste de nivel!", null);
    }
    public void TestDone(int curso_id, int correct)
    {
        if (level == 0 && correct >= 6)
            SetLevelUp();
    }
    public string GetLevelName()
    {
        if (level >= levels.Length)
            return levels[levels.Length - 1];
        else
            return levels[level];
    }
}
