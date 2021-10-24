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
                Question.text = $"�Ұ��� ���� �Ӹ��� �ٵ�����~";
                LeftText.text = $"�ʳ� �ٵ�������";
                RightText.text = $"���ڴ� �Ӹ�������";


                break;
            case 4:
                Question.text = $"�� �������� �Ӹ��� ǳ��������~ ����� ����?";
                LeftText.text = $"�߸���";
                RightText.text = $"�̿�� ���� �ؾ�";


                break;
            case 3:
                Question.text = $"���~ �ٸ����� �� �̷��� ����? �ν��ϴ°� �?";
                LeftText.text = $"��";
                RightText.text = $"�ƴϿ�";


                break;
            case 2:
                Question.text = $"��� �ٵ���ٱ�?";
                LeftText.text = $"������";
                RightText.text = $"������";

                condition = false;
                StageManager.Instance.player_information.object_id_arr[ID] = true;
                StageManager.Instance.player_information.HairCount++;
                StartCoroutine(Stage3Linker.Instance.ELogging("�ٸ����� �ν��� �Ӹ����� �����!"));
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
