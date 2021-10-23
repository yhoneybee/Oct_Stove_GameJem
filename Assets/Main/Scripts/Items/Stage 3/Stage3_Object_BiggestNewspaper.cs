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
        StartCoroutine(UIManager.Instance.ERotatingUI(MoveTarget, Vector3.forward * 180, 3));
        yield return StartCoroutine(UIManager.Instance.EMovingUI(MoveTarget, Vector2.zero, 3, true));

        Stage3Linker.Instance.ZoomedObjs.Bigger.gameObject.SetActive(false);

        var img = Stage3Linker.Instance.ZoomedObjs.Biggest.GetComponent<Image>();

        yield return StartCoroutine(UIManager.Instance.EColoringUI(img, Color.black, 3));
        gameObject.SetActive(false);
        img.sprite = Stage3Linker.Instance.ZoomedObjs.ChangeSprite;
        yield return StartCoroutine(UIManager.Instance.EColoringUI(img, Color.white, 3));

        Destroy(gameObject, 5);
    }
}
