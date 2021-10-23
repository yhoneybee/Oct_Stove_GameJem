using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Door : InteractiveObject
{
    protected override void Action()
    {
        condition = StageManager.Instance.player_information.HairCount == 3;

        if (condition)
        {
            SceneManager.Instance.ChangeScene("Road");
        }
    }
}
