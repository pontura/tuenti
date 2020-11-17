using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICursoButton : UIButton
{
    public GameObject locked;
    public GameObject doneGameObject;
    public Image image;
    public Text field;
    public DatabaseManager.CursoData data;
    public Sprite[] characters;

    public void OnInit(DatabaseManager.CursoData data, bool forceUnBlock)
    {
        this.data = data;
        field.text = data.nombre;
        bool isLocked = Data.Instance.databaseManager.IsCursoLocked(data.id);
        if (forceUnBlock)
            isLocked = false;
        locked.SetActive(isLocked);
        if (isLocked)
            GetComponent<Button>().interactable = false;
        image.sprite = characters[data.character_id];
        if (Data.Instance.userData.IsCursoDone(data.id))
            doneGameObject.SetActive(true);
        else
            doneGameObject.SetActive(false);
    }
}
