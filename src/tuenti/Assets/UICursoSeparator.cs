using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICursoSeparator : MonoBehaviour
{
    public Text field;
    public Text field2;

    public void Init(int id)
    {
        string t = Data.Instance.settings.levels[id].name;

        if (Data.Instance.settings.levels[id].totalVentas > 0)
            field2.text = "Ventas: " + Data.Instance.settings.levels[id].totalVentas;
        else
            field2.text = "";
       // t += Data.Instance.userData.GetLevelUnlockConditionTitle(id);
        field.text = t;
    }
}
