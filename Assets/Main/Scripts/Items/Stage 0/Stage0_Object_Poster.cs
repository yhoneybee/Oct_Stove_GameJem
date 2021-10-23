using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage0_Object_Poster : InteractiveObject
{
    Vector2 target_position;
    protected override void Start()
    {
        base.Start();

        target_position = transform.localPosition - new Vector3(0, 140);

        condition = true;
    }
    protected override void Action()
    {
        if (condition)
        {
            StartCoroutine(MoveToTarget());
            condition = false;
        }
    }

    IEnumerator MoveToTarget()
    {
        while (Vector2.Distance(transform.position, target_position) > 0.1f)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, target_position, 0.5f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}