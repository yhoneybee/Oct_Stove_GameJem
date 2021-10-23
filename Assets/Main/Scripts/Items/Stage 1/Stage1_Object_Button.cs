using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Button : InteractiveObject
{
    [SerializeField] Stage1_Object_Can object_can;

    // 서랍 열었을 때 보이는 아이콘들 (창에 있는애 아님)
    [SerializeField] GameObject can_icon;
    [SerializeField] GameObject button_icon;
    protected override void Action()
    {
        StageManager.Instance.player_information.object_id_arr[ID] = true;
        gameObject.SetActive(false);

        StageManager.Instance.player_information.object_id_arr[object_can.ID] = true;
        object_can.gameObject.SetActive(false);

        can_icon.SetActive(false);
        button_icon.SetActive(false);
    }
}
