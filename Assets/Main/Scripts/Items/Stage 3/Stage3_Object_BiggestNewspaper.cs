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
            StartCoroutine(UIManager.Instance.EMovingUI(MoveTarget, Vector2.zero, 3, true));
            StartCoroutine(UIManager.Instance.ERotatingUI(MoveTarget, Vector3.forward * 180, 3));
        }
    }
}
