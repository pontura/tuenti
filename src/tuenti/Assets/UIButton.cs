using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    UIScrollItemsScreen uiScrollItemsScreen;

    public void Init(UIScrollItemsScreen uiScrollItemsScreen)
    {
        this.uiScrollItemsScreen = uiScrollItemsScreen;
    }

    public void Clicked()
    {
        uiScrollItemsScreen.OnUIButtonClicked(this);
    }
}
