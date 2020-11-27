using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumersManager : MonoBehaviour
{
    public List<Costumer> all;

    public void Init()
    {
        if(Data.Instance.userData.costumersReady.Count == 0)
        {
            foreach (Costumer c in all)
                Data.Instance.userData.costumersReady.Add(0);
        }
        int id = 0;
        foreach (Costumer c in all)
        {
            c.id = id;
            if(c.isActiveAndEnabled)
                c.Init();

            if (Data.Instance.userData.costumersReady[id] == 1)
                c.SetState(true);
            else
                c.SetState(false);

            id++;
        }
        
    }
}
