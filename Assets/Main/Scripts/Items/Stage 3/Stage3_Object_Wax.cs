using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stage3_Object_Wax : InteractiveObject
{
    public Image Talk;
    public TextMeshProUGUI Question;

    public Image HairDresser;

    public Button Left;
    public TextMeshProUGUI LeftText;
    public Button Right;
    public TextMeshProUGUI RightText;

    public Image Fade;

    int count = 5;
    protected override void Start()
    {
        base.Start();
        Left.onClick.AddListener(() =>
        {
            switch (count)
            {
                case 5:
                    // WRONG
                    StageManager.Instance.player_information.player_save_data.timer -= 30;
                    break;
                case 4:
                    // WRONG
                    StageManager.Instance.player_information.player_save_data.timer -= 30;
                    break;
                case 3:
                    break;
                case 2:
                    // NONE
                    break;
            }

            StopAllCoroutines();
            StartCoroutine(EClose());
        });
        Right.onClick.AddListener(() =>
        {
            switch (count)
            {
                case 5:
                    break;
                case 4:
                    break;
                case 3:
                    //WRONG
                    StageManager.Instance.player_information.player_save_data.timer -= 30;
                    break;
                case 2:
                    break;
            }

            StopAllCoroutines();
            StartCoroutine(EClose());
        });
        condition = true;
    }
    protected override void Action()
    {
        StopAllCoroutines();
        if (condition) StartCoroutine(EChoose());
    }

    IEnumerator EChoose()
    {
        Talk.gameObject.SetActive(true);

        yield return StartCoroutine(UIManager.Instance.EColoringUI(GetComponent<Image>(), Color.clear, 3));
        StartCoroutine(UIManager.Instance.EMovingUI(HairDresser, Vector2.left * 749, 1000));
        StartCoroutine(UIManager.Instance.EColoringUI(HairDresser, Color.white, 3));

        switch (count)
        {
            case 5:
                Question.text = $"소개팅 전에 머리는 다듬어야지~";
                LeftText.text = $"너나 다듬으세요";
                RightText.text = $"남자는 머리빨이지";


                break;
            case 4:
                Question.text = $"오 저번보다 머리가 풍성해졌네~ 비결이 뭐야?";
                LeftText.text = $"발모제";
                RightText.text = $"미용사 님의 솜씨";


                break;
            case 3:
                Question.text = $"어머~ 다리털은 왜 이렇게 많아? 왁싱하는거 어때?";
                LeftText.text = $"네";
                RightText.text = $"아니오";


                break;
            case 2:
                Question.text = $"어떻게 다듬어줄까?";
                LeftText.text = $"샤기컷";
                RightText.text = $"일출컷";

                condition = false;
                StageManager.Instance.player_information.object_id_arr[ID] = true;
                StageManager.Instance.player_information.HairCount++;
                StartCoroutine(Stage3Linker.Instance.ELogging("다리털을 머리에 심습니다."));
                break;
        }

        Fade.raycastTarget = false;
        GetComponent<Button>().enabled = false;
        --count;

        yield return StartCoroutine(UIManager.Instance.EColoringUI(Fade, Color.clear, 3));

        yield return null;
    }

    IEnumerator EClose()
    {
        StartCoroutine(UIManager.Instance.EColoringUI(HairDresser, Color.clear, 3));
        yield return StartCoroutine(UIManager.Instance.EMovingUI(HairDresser, Vector2.zero, 1000));
        StartCoroutine(UIManager.Instance.EColoringUI(GetComponent<Image>(), Color.white, 3));
        yield return StartCoroutine(UIManager.Instance.EColoringUI(Fade, Color.black, 10));

        Talk.gameObject.SetActive(false);
        Fade.raycastTarget = true;
        GetComponent<Button>().enabled = true;
    }
}
