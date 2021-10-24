using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage0_Object_Ending : InteractiveObject
{
    protected override void Action()
    {
        SceneManager.Instance.ChangeScene("Inventotry");
    }
}
