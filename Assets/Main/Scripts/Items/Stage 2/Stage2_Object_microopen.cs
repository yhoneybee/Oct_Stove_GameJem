using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Object_microopen : InteractiveObject
{
    protected override void Action()
    {
        gameObject.SetActive(false);
    }
}
