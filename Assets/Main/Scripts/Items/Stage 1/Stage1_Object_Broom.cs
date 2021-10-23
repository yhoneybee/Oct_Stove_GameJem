using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Broom : InteractiveObject
{
    protected override void Start()
    {
        base.Start();

        condition = true;
    }
    protected override void Action()
    {
        if (condition)
        {
            StageManager.Instance.player_information.HairCount++;

            condition = false;
        }
    }
}
