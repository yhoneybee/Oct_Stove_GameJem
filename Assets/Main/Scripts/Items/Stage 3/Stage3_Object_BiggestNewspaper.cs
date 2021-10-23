using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stage3_Object_BiggestNewspaper : InteractiveObject
{
    public Image MoveTarget;
    protected override void Start()
    {
        base.Start();
        condition = true;
    }
    protected override void Action()
    {
        if (condition)
        {
            condition = false;

            StartCoroutine(EChangeSprite());

            StageManager.Instance.player_information.HairCount++;

        }
    }

    IEnumerator EChangeSprite()
    {
        StartCoroutine(UIManager.Instance.ERotatingUI(MoveTarget, Vector3.forward * 0, 3));
        yield return StartCoroutine(UIManager.Instance.EMovingUI(MoveTarget, new Vector2(110, -17), 3, true));

        var img = Stage3Linker.Instance.ZoomedObjs.Biggest.GetComponent<Image>();

        StartCoroutine(UIManager.Instance.EColoringUI(MoveTarget, Color.clear, 3));
        yield return StartCoroutine(UIManager.Instance.EColoringUI(img, Color.black, 3));
        img.sprite = Stage3Linker.Instance.ZoomedObjs.ChangeSprite;
        yield return StartCoroutine(UIManager.Instance.EColoringUI(img, Color.white, 3));
        Destroy(Stage3Linker.Instance.ZoomedObjs.Bigger.gameObject, 3);
        Stage3Linker.Instance.Buttons.ZoomParent.targetGraphic.raycastTarget = false;
    }
}
