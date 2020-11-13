using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizerButton : MonoBehaviour
{
    public CharacterCustomizer.Parts part;
    public GameObject locked;

    void Start()
    {
        Button b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(delegate () { OnClicked(); });
    }
    void OnClicked()
    {
        Events.OnCustomize(part.type, part.partID);
    }
}
