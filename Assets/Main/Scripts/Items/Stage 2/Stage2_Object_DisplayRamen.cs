using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Object_DisplayRamen : InteractiveObject
{
    // 진열장 창
    [SerializeField] GameObject DisplayRamen;

    protected override void Start()
    {
        base.Start();
        condition = true;
    }
    protected override void Action()
    {
        DisplayRamen.SetActive(true);
    }


}
