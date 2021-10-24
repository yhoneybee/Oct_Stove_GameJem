using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2_Object_Hair : InteractiveObject
{
    [SerializeField] GameObject OpenMicrowave;
    protected override void Action()
    {
            StageManager.Instance.player_information.HairCount++;
            OpenMicrowave.gameObject.SetActive(false);
    }
}
