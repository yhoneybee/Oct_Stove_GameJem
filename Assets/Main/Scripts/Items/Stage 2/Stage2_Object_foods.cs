using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_Object_foods : InteractiveObject
{
    [SerializeField] Image hintImg;
    bool show = false;
    protected override void Action()
    {
        show = true;
    }
    private void Update()
    {
        if (show)
        {
            hintImg.gameObject.SetActive(true);
        }
        else
            hintImg.gameObject.SetActive(false);
    }
    public void quit()
    {
        show = false;
    }
    public void on()
    {
        show = true;
    }
}
