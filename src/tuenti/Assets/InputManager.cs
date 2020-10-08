using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LeoLuz.PlugAndPlayJoystick;

public class InputManager : MonoBehaviour
{
    public Character character;
    public AnalogicKnob analogicKnob;

    void Update()
    {
        float _x = analogicKnob.NormalizedAxis.x;
        float _y = analogicKnob.NormalizedAxis.y;
        //float offset = 0.15f;
        //if (_x > offset) _x = 1; else if (_x < -offset) _x = -1;
        //if (_y > offset) _y= 1; else if (_y < -offset) _y = -1;
        if (character != null)
            character.MoveTo(_x, _y);
    }
}
