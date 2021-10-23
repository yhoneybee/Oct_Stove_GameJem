using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainLinker : MonoBehaviour
{
    public Image Before;
    public Image After;
    public Button Button;

    Coroutine CButton;

    private void Start()
    {
        Button.onClick.AddListener(() =>
        {
            if (CButton != null) StopCoroutine(CButton);
            CButton = StartCoroutine(UIManager.Instance.EMoveUI(Before, Vector2.zero, 1000));
        });
    }
}
