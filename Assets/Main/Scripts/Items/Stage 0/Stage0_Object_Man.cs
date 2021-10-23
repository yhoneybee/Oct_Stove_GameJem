using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage0_Object_Man : InteractiveObject
{
    [SerializeField] UnityEngine.UI.Image barikang;

    protected override void Start()
    {
        base.Start();

        condition = StageManager.Instance.player_information.object_id_arr[2];
    }
    protected override void Action()
    {
        if (condition)
        {
        barikang.gameObject.SetActive(true);
            barikang.rectTransform.localPosition = new Vector2(830, -275);

            StartCoroutine(UIManager.Instance.EMovingUI(barikang, new Vector2(830, -275 + 100), 5, true));

            StageManager.Instance.player_information.object_id_arr[2] = condition = false;

            Invoke("DestroyBarikang", 2);
        }
    }

    void DestroyBarikang()
    {
        barikang.gameObject.SetActive(false);
        StageManager.Instance.player_information.HairCount++;
    }
}
