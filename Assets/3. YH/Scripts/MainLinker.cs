using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainLinker : MonoBehaviour
{
    public List<Button> Buttons;
    public Image Before;
    public Image After;
    public Button Button;

    Coroutine CMovingUI;
    Coroutine CColoringUI_0;
    Coroutine CColoringUI_1;
    Coroutine CColoringUI_2;

    bool ui_move_up;
    bool appear_btn;

    private void Start()
    {
        ui_move_up = false;
        appear_btn = false;

        Button.onClick.AddListener(() =>
        {
            if (!ui_move_up)
            {
                ui_move_up = true;
                if (CMovingUI != null) StopCoroutine(CMovingUI);
                CMovingUI = StartCoroutine(UIManager.Instance.EMovingUI(Before, Vector2.zero, 1000));
            }
            else if (!appear_btn)
            {
                appear_btn = true;
                if (CColoringUI_0 != null) StopCoroutine(CColoringUI_0);
                CColoringUI_0 = StartCoroutine(UIManager.Instance.EColoringUI(Buttons[0].targetGraphic, Color.white, 3));
                if (CColoringUI_1 != null) StopCoroutine(CColoringUI_0);
                CColoringUI_1 = StartCoroutine(UIManager.Instance.EColoringUI(Buttons[1].targetGraphic, Color.white, 3));
                if (CColoringUI_2 != null) StopCoroutine(CColoringUI_0);
                CColoringUI_2 = StartCoroutine(UIManager.Instance.EColoringUI(Buttons[2].targetGraphic, Color.white, 3));

                Button.enabled = false;
            }
        });
    }
}