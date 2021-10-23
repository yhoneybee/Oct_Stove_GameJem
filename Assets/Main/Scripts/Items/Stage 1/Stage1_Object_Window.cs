using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Window : InteractiveObject
{
    protected override void Start()
    {
        base.Start();

    }
    protected override void Action()
    {
        condition = StageManager.Instance.player_information.object_id_arr[0] == 1 && StageManager.Instance.player_information.object_id_arr[1] == 1;
        if (condition)
        {
            StageManager.Instance.player_information.HairCount++;
            StageManager.Instance.player_information.object_id_arr[0] = StageManager.Instance.player_information.object_id_arr[1] = 0;
        }
    }
}
