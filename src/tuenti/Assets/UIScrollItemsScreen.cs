using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollItemsScreen : UIPanelScreen
{
    public UIButton uiButton_to_instantiate;
    public Transform container;
    [HideInInspector] public UIButton uiButton;

    public override void Init()
    {        
        base.Init();
        panel.SetActive(true);
    }
    
    public void Reset()
    {
        Utils.RemoveAllChildsIn(container);
    }
    public virtual UIButton AddItem()
    {
        UIButton newButton = Instantiate(uiButton_to_instantiate, container);
        this.uiButton = newButton;
        newButton.Init(this);
        return newButton;
    }
    public virtual void OnUIButtonClicked(UIButton uiButton) {  }
}
