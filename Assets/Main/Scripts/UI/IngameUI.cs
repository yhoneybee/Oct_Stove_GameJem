using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hair_count_text;
    [SerializeField] TextMeshProUGUI timer_text;

    [SerializeField] RectTransform side_ui;

    [SerializeField] RectTransform current_transform;
    [SerializeField] RectTransform target_transform;

    [SerializeField] Button side_ui_button;

    RectTransform side_ui_button_transform;
    Coroutine rotation_coroutine = null;
    Coroutine onoff_coroutine = null;

    public int current_count = 0;
    bool is_side_ui_appeard = true;
    void Start()
    {
        side_ui_button.onClick.AddListener(() =>
        {
            if (rotation_coroutine != null)
                StopCoroutine(rotation_coroutine);
            
            rotation_coroutine = StartCoroutine(RotationButton());

            if (onoff_coroutine != null)
                StopCoroutine(onoff_coroutine);

            onoff_coroutine = StartCoroutine(OnOffSideUI());
        });

        side_ui_button_transform = side_ui_button.GetComponent<RectTransform>();

        current_count = StageManager.Instance.timer;
        InvokeRepeating("CountDown", 0, 1);
    }

    void Update()
    {

        hair_count_text.text = $"{StageManager.Instance.player_information.HairCount} / {StageManager.Instance.need_hair_count}";
    }
    void CountDown()
    {
        current_count--;

        timer_text.text = $"{current_count / 60} : {current_count % 60}";
    }

    IEnumerator RotationButton()
    {
        bool is_side_ui_appeard = this.is_side_ui_appeard;

        while (Quaternion.Angle(side_ui_button_transform.rotation, Quaternion.Euler(0, 0, is_side_ui_appeard ? 180 : 0)) > 0.1f)
        {
            side_ui_button_transform.rotation = Quaternion.Lerp(side_ui_button_transform.rotation, Quaternion.Euler(0, 0, is_side_ui_appeard ? 180 : 0), 0.5f);
            yield return new WaitForSeconds(0.01f);
        }

        rotation_coroutine = null;
    }
    IEnumerator OnOffSideUI()
    {
        while (Vector2.Distance(side_ui.position, is_side_ui_appeard ? target_transform.position : current_transform.position) > 0.1f)
        {
            side_ui.position = Vector3.Lerp(side_ui.position, is_side_ui_appeard ? target_transform.position : current_transform.position, 0.5f);
            yield return new WaitForSeconds(0.01f);
        }
        is_side_ui_appeard = !is_side_ui_appeard;

        onoff_coroutine = null;
    }
}
