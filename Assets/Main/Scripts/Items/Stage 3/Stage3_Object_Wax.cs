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
        switch (count)
        {
            case 5:
                break;
            case 4:
                break;
            case 3:
                break;
            case 2:
                break;
            case 1:
                break;
            case 0:
                if (condition)
                {
                    condition = false;
                    StageManager.Instance.player_information.object_id_arr[ID] = true;
                    StageManager.Instance.player_information.HairCount++;
                }
                break;
        }
        --count;
    }
}
