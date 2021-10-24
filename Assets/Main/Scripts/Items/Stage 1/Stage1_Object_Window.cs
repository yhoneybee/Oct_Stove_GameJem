using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Window : InteractiveObject
{
    [SerializeField] GameObject cat_window;

    [SerializeField] GameObject image2;
    protected override void Start()
    {
        base.Start();

    }
    protected override void Action()
    {
        condition = StageManager.Instance.player_information.object_id_arr[0] && StageManager.Instance.player_information.object_id_arr[1];
        if (condition)
        {
            StartCoroutine(ShowImages());

            condition = false;
        }
    }

    IEnumerator ShowImages()
    {
        cat_window.SetActive(true);
        yield return new WaitForSeconds(1);
        image2.SetActive(true);
        StageManager.Instance.player_information.HairCount++;
        StageManager.Instance.player_information.object_id_arr[0] = StageManager.Instance.player_information.object_id_arr[1] = false;
        yield return new WaitForSeconds(1);
        cat_window.SetActive(false);
    }
}
