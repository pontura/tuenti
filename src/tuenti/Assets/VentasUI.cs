using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentasUI : MonoBehaviour
{
    void Start()
    {
        Data.Instance.userData.venta_active_id = 1;
        GetComponent<CursoContentUI>().Init(CursoContentUI.types.VENTA);
    }
}
