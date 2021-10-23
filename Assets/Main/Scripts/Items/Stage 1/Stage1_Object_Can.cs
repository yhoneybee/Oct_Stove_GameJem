using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Can : InteractiveObject
{
    public Stage1_Object_Button object_button;

    protected override void Action()
    {
        StageManager.Instance.player_information.object_id_arr[ID] = 1;
        gameObject.SetActive(false);

        StageManager.Instance.player_information.object_id_arr[object_button.ID] = 1;
        object_button.gameObject.SetActive(false);
    }
}
