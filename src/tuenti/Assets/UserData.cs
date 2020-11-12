using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UserData : MonoBehaviour
{
    public bool isLogged;
  
    public string username;
    public string dni;
    public int curso_active_id;
    public int venta_active_id;
    public int level;
    public int ventas;
    public int curso_id;
    int totalBooks = 6;

    public List<int> cursosDone;
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
        dni = PlayerPrefs.GetString("dni");
        level = PlayerPrefs.GetInt("level", 0);
        curso_id = PlayerPrefs.GetInt("curso_id", 0);
        ventas = PlayerPrefs.GetInt("ventas", 0);

        string[] arr = PlayerPrefs.GetString("cursosDone").Split(","[0]);
        print(arr.Length + PlayerPrefs.GetString("cursosDone"));
        if (arr != null && arr.Length > 1)
        {
            foreach (string s in arr)
                if(s != "") cursosDone.Add(int.Parse(s));
        }

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
    public void VentaDone(bool success)
    {
        if (success)
        {
            ventas++;
            PlayerPrefs.SetInt("ventas", ventas);
        }
        venta_active_id++;
        if (venta_active_id >= Data.Instance.databaseManager.ventasData.all.Length)
            venta_active_id = 0;
        PlayerPrefs.SetInt("venta_active_id", venta_active_id);
    }
    public void Register(string _username, string _dni)
    {
        PlayerPrefs.SetString("username", _username);
        PlayerPrefs.SetString("dni", _dni);
        username = _username;
        dni = _dni;
    }
    public void SetLevelUp()
    {
        level++;
        PlayerPrefs.SetInt("level", level);
        Events.OnConfirmation("¡Felicitaciones!, ahora sos " + Data.Instance.settings.levels[level].name, null);
    }

    public string GetLevelName()
    {
        if (level >= Data.Instance.settings.levels.Length)
            return Data.Instance.settings.levels[Data.Instance.settings.levels.Length - 1].name;
        else
            return Data.Instance.settings.levels[level].name;
    }
    public void SetNewCursoDone(int curso_id)
    {
        foreach (int a in cursosDone)
            if (a == curso_id)
                return;
        cursosDone.Add(curso_id);

        string s = "";
        foreach (int a in cursosDone)
            s += a + ",";

        PlayerPrefs.SetString("cursosDone", s);
    }
    public bool IsCursoDone(int curso_id)
    {
        foreach (int a in cursosDone)
            if (a == curso_id)
                return true;
        return false;
    }

    public void CheckToUnlockLevel()
    {
        int id = 0;
        int totalLevels = 0;
        foreach (Settings.LevelData levelData in Data.Instance.settings.levels)
        {
            totalLevels += levelData.totalCursos;
            foreach (DatabaseManager.CursoData d in Data.Instance.databaseManager.cursosData.all)
            {
                print("id: " + id + "  totalLevels: " + totalLevels + "  d.test_score: " + d.test_score + "  level: " + level);
                if (level == id && id < totalLevels && d.test_score == 0 && (level != 0 && id != 0))
                    return;
                id++;
            }            
        }
        SetLevelUp();
    }
}
