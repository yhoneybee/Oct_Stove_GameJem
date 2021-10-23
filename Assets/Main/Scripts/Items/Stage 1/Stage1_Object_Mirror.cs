using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Mirror : InteractiveObject
{
    [SerializeField] GameObject mirror;
    protected override void Action()
    {
        mirror.SetActive(true);
    }
}
