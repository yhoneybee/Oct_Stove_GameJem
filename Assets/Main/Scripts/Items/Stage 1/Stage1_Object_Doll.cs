using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Doll : InteractiveObject
{
    [SerializeField] GameObject doll_window;

    [SerializeField] GameObject hair;
    protected override void Start()
    {
        base.Start();

        condition = true;
    }
    protected override void Action()
    {
        if (condition)
        {
            StartCoroutine(ShowImage());

            condition = false;
        }
    }

    IEnumerator ShowImage()
    {
        doll_window.SetActive(true);
        yield return new WaitForSeconds(1f);

        StageManager.Instance.player_information.HairCount++;
        hair.SetActive(false);

        yield return new WaitForSeconds(1f);
        doll_window.SetActive(false);
    }
}