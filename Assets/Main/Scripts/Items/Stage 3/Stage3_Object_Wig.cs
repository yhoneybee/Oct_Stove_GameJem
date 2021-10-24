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
        StartCoroutine(ELog());
    }

    IEnumerator ELog()
    {
        yield return StartCoroutine(Stage3Linker.Instance.ELogging("가발에 있는 머리카락을 뜯어 머리털을 얻었다!"));
        Destroy(gameObject);
    }
}
