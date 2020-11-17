using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colorizer : MonoBehaviour
{
    public Image[] ui_parts;
    public SpriteRenderer[] parts;
	public Color[] colors;

	void OnEnable()
	{
        StartCoroutine(WaitToColor());
	}
    IEnumerator WaitToColor()
    {
        yield return new WaitForEndOfFrame();
        Color c = colors[Random.Range(0, colors.Length)];

        foreach (Image sr in ui_parts)
        {
            sr.color = c;
        }
        foreach (SpriteRenderer sr in parts)
        {
            sr.color = c;
        }
    }
}
