using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingButtonUI : UIButton
{
    public Text usernameField;
    public Text scoreField;
    public Text puestoField;
    public DatabaseManager.RankingDataLine data;

    public void OnInit(DatabaseManager.RankingDataLine data,int puesto)
    {
        this.data = data;
        usernameField.text = data.nombre;
        scoreField.text = data.score.ToString();
        puestoField.text = puesto.ToString();
    }
}
