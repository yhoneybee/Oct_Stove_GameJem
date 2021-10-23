using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staage2_Obj_Manager : InteractiveObject
{
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
