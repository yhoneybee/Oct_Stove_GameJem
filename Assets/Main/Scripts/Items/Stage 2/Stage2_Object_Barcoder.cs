using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_Object_Barcoder : InteractiveObject
{
    [SerializeField] Image ramenhair;
    protected override void Start()
    {
        base.Start();

        condition = true;
    }
    protected override void Action()
    {
        if (StageManager.Instance.player_information.object_id_arr[3] == true && condition)
        {
            ramenhair.gameObject.SetActive(true);
            StageManager.Instance.player_information.object_id_arr[3] = false;
        }
    }
}
