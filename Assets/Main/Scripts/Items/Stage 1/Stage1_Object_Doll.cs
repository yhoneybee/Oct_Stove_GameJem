using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Doll : InteractiveObject
{
    public GameObject[] hair = new GameObject[2];
    protected override void Start()
    {
        base.Start();

        condition = true;
    }
    protected override void Action()
    {
        if(condition)
        {
            StageManager.Instance.player_information.HairCount++;

            hair[0].SetActive(false);
            hair[1].SetActive(false);

            condition = false;
        }
    }
}