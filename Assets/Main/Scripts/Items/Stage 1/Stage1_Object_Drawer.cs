using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Object_Drawer : InteractiveObject
{
    // 서랍 창
    [SerializeField] GameObject drawer;
    // 서랍 열었을 때 이동시킬 위치
    [SerializeField] RectTransform target_transform;

    bool is_opened = false;
    protected override void Start()
    {
        base.Start();

        condition = true;
    }
    protected override void Action()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        yield return StartCoroutine(MoveDrawer());

        drawer.SetActive(true);
    }
    IEnumerator MoveDrawer()
    {
        RectTransform rt = GetComponent<RectTransform>();
        while (Vector2.Distance(rt.position, target_transform.position) > 0.1f)
        {
            rt.position = Vector2.Lerp(rt.position, target_transform.position, 0.5f);
            yield return new WaitForSeconds(0.01f);
        }

        if (!is_opened)
        {
            is_opened = true;
            yield return new WaitForSeconds(1);
        }
    }
}
