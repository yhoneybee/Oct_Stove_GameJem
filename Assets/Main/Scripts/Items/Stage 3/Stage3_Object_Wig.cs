using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_Object_Wig : InteractiveObject
{
    protected override void Start()
    {
        base.Start();
        condition = true;
    }
    protected override void Action()
    {
        StageManager.Instance.player_information.object_id_arr[ID] = true;
        StageManager.Instance.player_information.HairCount++;
        Destroy(gameObject);
    }
}
