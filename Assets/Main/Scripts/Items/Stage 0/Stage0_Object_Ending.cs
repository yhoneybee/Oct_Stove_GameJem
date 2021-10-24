using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage0_Object_Ending : InteractiveObject
{
    protected override void Action()
    {
        if (StageManager.Instance.player_information.HairCount >= 11)
            SceneManager.Instance.ChangeScene("Inventory");
    }
}
