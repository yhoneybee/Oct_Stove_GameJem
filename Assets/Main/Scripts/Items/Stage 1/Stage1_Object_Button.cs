using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Button : InteractiveObject
{
    [SerializeField] Stage1_Object_Can object_can;
    protected override void Action()
    {
        StageManager.Instance.player_information.object_id_arr[ID] = 1;
        gameObject.SetActive(false);

        StageManager.Instance.player_information.object_id_arr[object_can.ID] = 1;
        object_can.gameObject.SetActive(false);
    }
}
