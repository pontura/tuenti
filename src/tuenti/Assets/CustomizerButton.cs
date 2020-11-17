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
        bool isLocked;
        if (part.partID == -1)
            isLocked = false;
        else
            isLocked = Data.Instance.userData.IsCostumizationLocked(part.type, part.partID);

        if (isLocked)
        {
            locked.SetActive(true);
            GetComponent<Button>().interactable = false;
        }
        else
        {
            locked.SetActive(false);
            GetComponent<Button>().interactable = true;
        }
    }
    void OnClicked()
    {
        Events.OnCustomize(part.type, part.partID);
    }
}
