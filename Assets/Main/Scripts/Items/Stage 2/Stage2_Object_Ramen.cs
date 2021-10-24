using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Object_Ramen : InteractiveObject
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
            StageManager.Instance.player_information.object_id_arr[ID] = true;

            gameObject.SetActive(false);

            condition = false;
        }
    }
}
