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
}
