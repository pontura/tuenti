using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    bool isOn;
    private void Start()
    {
        if (Data.Instance.userData.curso_id >= Data.Instance.databaseManager.cursosData.all.Length)
            isOn = true;
    }
    private void OnTriggerEnter(Collider other)
    {       
        if (other.tag == "Player")
        {
            if (isOn)
                Events.OnConfirmation("Felicitaciones, estás listo para el test final", Talked);
            else
                Events.OnConfirmation("¡Pana! Todavía no estás listo para verme. Cuando termines todos los cursos, ahí te puedes acercar para tomar el test final.", null);
        }
    }
    void Talked()
    {
        Data.Instance.userData.Talk_Samuel();
        Game.Instance.GotoTests();
    }
}
