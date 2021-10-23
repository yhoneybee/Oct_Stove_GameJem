using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stage3_Object_Light : InteractiveObject
{
    Coroutine CChangeColor;

    protected override void Start()
    {
        base.Start();
        condition = true;
    }
    protected override void Action()
    {
        if (CChangeColor != null) StopCoroutine(CChangeColor);
        CChangeColor = StartCoroutine(EChangeColor());
    }

    IEnumerator EChangeColor()
    {
        var wait = new WaitForSeconds(0.8f);
        var img = GetComponent<Image>();

        List<Color> colors = new List<Color>()
        {
            Color.red,Color.red,Color.green,Color.red,Color.yellow,Color.green,Color.green
        };

        for (int i = 0; i < colors.Count; i++)
        {
            img.color = colors[i];
            yield return wait;
            img.color = Color.black;
            yield return wait;
        }

        yield return null;
    }
}
