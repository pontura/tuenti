using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingUI : UIScrollItemsScreen
{
    public override void Init()
    {
        LoadData();
    }
    void LoadData()
    {
        Reset();
        base.Init();

        DatabaseManager.RankingDataLine[] rankingData = Data.Instance.databaseManager.rankingData.all;

        int puesto = 1;
        foreach (DatabaseManager.RankingDataLine line in rankingData)
        {
            RankingButtonUI newButton = (RankingButtonUI)AddItem();
            newButton.OnInit(line, puesto);
            puesto++;
        }
    }
}
