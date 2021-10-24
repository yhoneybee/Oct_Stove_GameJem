using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage3_Object_CuttingHairPicture : InteractiveObject
{
    protected override void Start()
    {
        base.Start();
        condition = true;
    }
    protected override void Action()
    {
        StageManager.Instance.player_information.object_id_arr[ID] = true;
        Stage3Linker.Instance.ZoomedObjs.PuzzleSuccessImg.sprite = Stage3Linker.Instance.ZoomedObjs.PuzzleSuccessAndGotten;
        Stage3Linker.Instance.Buttons.PuzzleDrawer.GetComponent<Image>().color = Color.clear;
        Destroy(gameObject);
    }
}
