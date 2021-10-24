using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct Buttons
{
    public Button ZoomParent;
    public Button CombDrawer;
    public Button PuzzleDrawer;
    public Button PlayPuzzle;
    public Button GetCuttingPicture;
    public Button LightDrawer;
    public Button News;
    public Button BiggerNews;
    public Button BiggestNews;
}
[System.Serializable]
public struct ZoomedObjs
{
    [Header("- CombDrawer UI -")]
    public RectTransform CombDrawer;

    [Header("- Puzzle UI -")]
    public RectTransform PuzzleDrawer;
    public Image PuzzleSuccessImg;
    public Sprite PuzzleSuccess;
    public Sprite PuzzleSuccessAndGotten;

    [Header("- LightDrawer UI -")]
    public RectTransform LightDrawer;

    [Header("- Newspaper UI -")]
    public RectTransform Bigger;
    public RectTransform Biggest;
    public Sprite ChangeSprite;
}

public class Stage3Linker : MonoBehaviour
{
    public static Stage3Linker Instance { get; private set; } = null;

    public Image Bg;
    public Button Left;
    public Button Right;
    public Button Down;

    public GameObject PuzzleGame;
    public TextMeshProUGUI LogText;

    public ZoomedObjs ZoomedObjs;
    public Buttons Buttons;

    GameObject ActiveObj;

    Coroutine CMovingUI;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Down.onClick.AddListener(() => 
        {
            SceneManager.Instance.ChangeScene("Road");
        });

        // �ݱ� ��
        Buttons.ZoomParent.onClick.AddListener(() =>
        {
            if (ActiveObj)
            {
                ActiveObj.SetActive(false);
                ZoomParent(false);
                if (ZoomedObjs.Biggest.gameObject)
                    ZoomedObjs.Biggest.gameObject.SetActive(false);
            }
        });

        // �׳� ����
        Buttons.CombDrawer.onClick.AddListener(() =>
        {
            ZoomParent(true);
            ShowZoomedObj(ZoomedObjs.CombDrawer.gameObject);
        });

        // ���񼭶�
        Buttons.PuzzleDrawer.onClick.AddListener(() =>
        {
            ZoomParent(true);
            ShowZoomedObj(ZoomedObjs.PuzzleDrawer.gameObject);
        });

        // ���� ����
        Buttons.PlayPuzzle.onClick.AddListener(() =>
        {
            PuzzleGame.SetActive(true);
        });

        // ����Ʈ ����
        Buttons.LightDrawer.onClick.AddListener(() =>
        {
            ZoomParent(true);
            ShowZoomedObj(ZoomedObjs.LightDrawer.gameObject);
        });

        // ����
        Buttons.News.onClick.AddListener(() =>
        {
            ZoomParent(true);
            ShowZoomedObj(ZoomedObjs.Bigger.gameObject);
        });

        // ū ����
        Buttons.BiggerNews.onClick.AddListener(() =>
        {
            if (StageManager.Instance.player_information.object_id_arr[5]) // YHTODO : ���⿡�� ������ ������ �ִ��� Ȯ��
            {
                ZoomedObjs.Biggest.gameObject.SetActive(true);
            }
        });

        //�¿� ȭ��ǥ
        Left.onClick.AddListener(() =>
        {
            if (CMovingUI != null) StopCoroutine(CMovingUI);
            CMovingUI = StartCoroutine(UIManager.Instance.EMovingUI(Bg, Vector2.right * 960, 5, true));
        });
        Right.onClick.AddListener(() =>
        {
            if (CMovingUI != null) StopCoroutine(CMovingUI);
            CMovingUI = StartCoroutine(UIManager.Instance.EMovingUI(Bg, Vector2.left * 960, 5, true));
        });
    }

    public IEnumerator ELogging(string str)
    {
        LogText.text = str;
        yield return StartCoroutine(UIManager.Instance.EColoringUI(LogText, Color.black, 3));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(UIManager.Instance.EColoringUI(LogText, Color.clear, 3));
        LogText.text = "";
        yield return null;
    }

    private void ShowZoomedObj(GameObject obj)
    {
        obj.SetActive(true);
        ActiveObj = obj;
    }

    private void ZoomParent(bool value)
    {
        Buttons.ZoomParent.enabled = value;
        Buttons.ZoomParent.targetGraphic.raycastTarget = value;
    }
}
