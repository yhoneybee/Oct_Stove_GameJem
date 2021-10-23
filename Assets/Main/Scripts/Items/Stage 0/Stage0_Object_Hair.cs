using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage0_Object_Hair : InteractiveObject
{
    protected override void Action()
    {
        StageManager.Instance.player_information.HairCount++;

        gameObject.SetActive(false);
    }
}
