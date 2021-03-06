﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public types type;
    public Sprite sprite;

    public enum types
    {
        TO_ACADEMY,
        TO_CITY,
        TO_HOME
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch(type)
            {
                case types.TO_ACADEMY:
                    Events.OnConfirmationImage(Data.Instance.textsManager.texts.all.door_to_academy, sprite, Goto);  break;
                case types.TO_CITY:
                    Events.OnConfirmation(Data.Instance.textsManager.texts.all.door_to_city, Goto);  break;
                case types.TO_HOME:
                    Events.OnConfirmationImage(Data.Instance.textsManager.texts.all.door_to_home, sprite, Goto);                       
                    break;
            }            
        }
    }
    void Goto()
    {
        switch (type)
        {
            case types.TO_ACADEMY:
                Game.Instance.mapManager.ChangeRoom(1);   break;
            case types.TO_CITY:
                Game.Instance.mapManager.ChangeRoom(0);   break;
            case types.TO_HOME:
                Data.Instance.uiUserPanel.OnInit(); break;
        }
    }
}
