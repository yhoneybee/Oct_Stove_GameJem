using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sstage1_Object_Barikang : InteractiveObject
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
