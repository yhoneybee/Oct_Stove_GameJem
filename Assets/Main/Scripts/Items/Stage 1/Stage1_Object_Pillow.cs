using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Pillow : InteractiveObject
{
    Vector2 target_position;

    protected override void Start()
    {
        base.Start();

        target_position = new Vector2(0, - 75f);
    }
    protected override void Action()
    {
        StartCoroutine(MoveToTarget());
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
