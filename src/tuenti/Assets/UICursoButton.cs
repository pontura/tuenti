using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICursoButton : UIButton
{
    public GameObject locked;
    public Image image;
    public Text field;
    public DatabaseManager.CursoData data;
    public Sprite[] characters;

    public void OnInit(DatabaseManager.CursoData data)
    {
        this.data = data;
        field.text = data.nombre;
        bool isLocked = Data.Instance.databaseManager.IsCursoLocked(data.id);
        locked.SetActive(isLocked);
        if (isLocked)
            GetComponent<Button>().interactable = false;
        image.sprite = characters[data.character_id];
    }
}
