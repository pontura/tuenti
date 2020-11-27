﻿using System.Collections;
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
    public List<int> costumersReady;
    public int costumerID;

    private void Awake()
    {
        Events.GetBook += GetBook;
    }
    private void OnDestroy()
    {
        Events.GetBook -= GetBook;
    }
    public void ResetCostumersReady()
    {
        for (int a = 0; a < costumersReady.Count; a++)
            costumersReady[a] = 0;
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
        print("______IsCursoDone " + curso_id);
        foreach (int a in cursosDone)
            if (a == curso_id)
                return true;
        return false;
    }

    public void CheckToUnlockLevel()
    {
        int levelID = 0;
        int id = 0;
        int totalLevels = 0;
        foreach (Settings.LevelData levelData in Data.Instance.settings.levels)
        {
            totalLevels = levelData.totalCursos;
            foreach (DatabaseManager.CursoData d in Data.Instance.databaseManager.cursosData.all)
            {
                if (level == levelID)
                {
                    print("id: " + id + "   levelID: " + levelID + "   totalLevels: " + totalLevels + "   d.test_score: " + d.test_score + "   level: " + level);
                    if (levelID == 0 && id == 0)
                        print("first level");
                    else if (id < totalLevels && d.test_score == 0)
                        return;                    
                    id++;
                }
            }
            levelID++;
        }
        SetLevelUp();
    }
    public string GetLevelUnlockConditionTitle(int levelID)
    {
        switch(levelID)
        {
            case 1:
                return "(Tests + 1 venta)";
            case 2:
                return "(Tests + 3 ventas)";
            case 3:
                return "(Tests + 7 ventas)";
            case 4:
                return "(Tests + 10 ventas)";
            default:
                return "";
        }
    }
    public bool IsCostumizationLocked(CharacterCustomizer.Types type, int id)
    {
        bool locked = true;
        switch(type)
        {
            case CharacterCustomizer.Types.HATS:
                if (level >= 0 && id == 0) locked = false;
                if (level >= 3 && id == 1) locked = false;
                if (level >= 4 && id == 2) locked = false;
                break;
            case CharacterCustomizer.Types.GLASSES:
                if (level >= 0 && id == 0) locked = false;
                if (level >= 2 && id == 1) locked = false;
                if (level >= 4 && id == 2) locked = false;
                break;
            case CharacterCustomizer.Types.COLLARS:
                if (level >= 0 && id == 0) locked = false;
                if (level >= 1 && id == 1) locked = false;
                if (level >= 3 && id == 2) locked = false;
                break;
            case CharacterCustomizer.Types.MOUSTACHES:
                if (level >= 1 && id == 0) locked = false;
                if (level >= 2 && id == 1) locked = false;
                if (level >= 3 && id == 2) locked = false;
                break;
            case CharacterCustomizer.Types.EARINGS:
                if (level >= 1 && id == 1) locked = false;
                if (level >= 2 && id == 0) locked = false;
                if (level >= 4 && id == 2) locked = false;
                break;
        }
        return locked;
    }
}
