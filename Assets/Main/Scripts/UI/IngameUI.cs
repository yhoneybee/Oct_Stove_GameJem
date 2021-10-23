using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    [SerializeField] RectTransform side_ui;

    [SerializeField] RectTransform current_transform;
    [SerializeField] RectTransform target_transform;

    [SerializeField] Button side_ui_button;

    RectTransform side_ui_button_transform;

    bool is_side_ui_appeard = true;
    void Start()
    {
        side_ui_button.onClick.AddListener(() => { StartCoroutine(OnOffSideUI()); });

        side_ui_button_transform = side_ui_button.GetComponent<RectTransform>();
    }

    void Update()
    {
        side_ui_button_transform.rotation = Quaternion.Lerp(side_ui_button_transform.rotation, Quaternion.Euler(0, 0, !is_side_ui_appeard ? 180 : 0), 0.5f);
    }
    IEnumerator OnOffSideUI()
    {
        while (Vector2.Distance(side_ui.position, is_side_ui_appeard ? target_transform.position : current_transform.position) > 0.1f)
        {
            side_ui.position = Vector2.Lerp(side_ui.position, is_side_ui_appeard ? target_transform.position : current_transform.position, 0.5f);
            yield return new WaitForSeconds(0.01f);
        }
        is_side_ui_appeard = !is_side_ui_appeard;
    }
}
