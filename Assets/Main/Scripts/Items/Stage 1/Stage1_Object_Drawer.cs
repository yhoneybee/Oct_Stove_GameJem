using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Drawer : InteractiveObject
{
    [SerializeField] GameObject Drawer;
    protected override void Start()
    {
        base.Start();

        condition = true;
    }
    protected override void Action()
    {
        Drawer.SetActive(true);
    }
}
