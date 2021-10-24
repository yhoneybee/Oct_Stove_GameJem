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

    public GameObject PuzzleGame;

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
        // 닫기 용
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

        // 그냥 서랍
        Buttons.CombDrawer.onClick.AddListener(() =>
        {
            ZoomParent(true);
            ShowZoomedObj(ZoomedObjs.CombDrawer.gameObject);
        });

        // 퍼즐서람
        Buttons.PuzzleDrawer.onClick.AddListener(() =>
        {
            ZoomParent(true);
            ShowZoomedObj(ZoomedObjs.PuzzleDrawer.gameObject);
        });

        // 퍼즐 시작
        Buttons.PlayPuzzle.onClick.AddListener(() =>
        {
            PuzzleGame.SetActive(true);
        });

        // 라이트 서랍
        Buttons.LightDrawer.onClick.AddListener(() =>
        {
            ZoomParent(true);
            ShowZoomedObj(ZoomedObjs.LightDrawer.gameObject);
        });

        // 뉴스
        Buttons.News.onClick.AddListener(() =>
        {
            ZoomParent(true);
            ShowZoomedObj(ZoomedObjs.Bigger.gameObject);
        });

        // 큰 뉴스
        Buttons.BiggerNews.onClick.AddListener(() =>
        {
            if (StageManager.Instance.player_information.object_id_arr[6]) // YHTODO : 여기에서 사진을 가지고 있는지 확인
            {
                ZoomedObjs.Biggest.gameObject.SetActive(true);
            }
        });

        //좌우 화살표
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
