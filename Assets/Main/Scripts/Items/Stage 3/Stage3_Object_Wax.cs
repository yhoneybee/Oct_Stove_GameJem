using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_Object_Wax : InteractiveObject
{
    int count = 5;
    protected override void Start()
    {
        base.Start();
        condition = true;
    }
    protected override void Action()
    {
        --count;
        if (count == 0 && condition)
        {
            condition = false;
            StageManager.Instance.player_information.object_id_arr[ID] = true;
            StageManager.Instance.player_information.HairCount++;
        }
    }
}
