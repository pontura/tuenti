using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Settings : MonoBehaviour
{
    public LevelData[] levels;
    [Serializable]
    public class LevelData
    {
        public string name;
        public int totalCursos;
        public int totalVentas;
    }
    public Color costumerDoneColor;
    public Color costumerIdleColor;

    public Color[] remerasColor;
    public Color[] pantalonesColor;
    public Color[] zapasColor;

    public List<int> GetCursosIdByLevel()
    {
        List<int> arr = new List<int>();
        int num = 0;
        foreach(LevelData ld in levels)
        {
            num += ld.totalCursos;
            arr.Add(num);
        }
        return arr;
    }
}
