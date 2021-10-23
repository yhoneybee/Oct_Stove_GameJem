using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockLogic : MonoBehaviour
{
    [SerializeField] Color[] right_colors;
    [SerializeField] Color[] select_colors;

    [SerializeField] RectTransform fade_rect_transform;

    int colors_index = 0;
    bool logic_clear = false;

    void Start()
    {
        select_colors = new Color[right_colors.Length];
    }
    void Update()
    {
    }
    bool CheckRight()
    {
        int right_count = 0;

        for (int i = 0; i < select_colors.Length; i++)
            if (select_colors[i] == right_colors[i])
                right_count++;

        return right_count == select_colors.Length;
    }
    IEnumerator SelectBlockAnimation(Transform tr)
    {
        float sin_value = 0;
        while (sin_value < 360)
        {
            sin_value += 10;
            tr.position = tr.position + Vector3.up * Mathf.Sin(sin_value * Mathf.Deg2Rad) * 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator FadeImage(Image image, params Color[] colors)
    {
        float time;
        for (int i = 0; i < colors.Length; i++)
        {
            time = Time.time;
            while (Time.time - time < 0.5f)
            {
                image.color = Color.Lerp(image.color, colors[i], 0.1f);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
    public void SelectBlock(RectTransform rect_transform)
    {
        StartCoroutine(SelectBlockAnimation(rect_transform));

        Image image = rect_transform.GetComponent<Image>();
        Color color = image.color;

        select_colors[colors_index++] = color;

        if (colors_index >= select_colors.Length)
        {
            logic_clear = CheckRight();
            colors_index = 0;

            if (logic_clear)
            {
                // 성공 시 실행할 내용
            }
            else
            {
                CameraManager.Instance.ShakeCamera(5, 3f);
                StartCoroutine(FadeImage(fade_rect_transform.GetComponent<Image>(), new Color(1, 0, 0, 0.5f), new Color(0, 0, 0, 0)));
            }

            Debug.Log(logic_clear);
            if (Stage3Linker.Instance)
            {
                if (logic_clear)
                {
                    Stage3Linker.Instance.ZoomedObjs.PuzzleSuccessImg.sprite = Stage3Linker.Instance.ZoomedObjs.PuzzleSuccess;
                    Stage3Linker.Instance.Buttons.GetCuttingPicture.gameObject.SetActive(true);
                }
                Stage3Linker.Instance.PuzzleGame.SetActive(false);
            }
            return;
        }
    }
    public void CancelSelect() => colors_index = 0;
}
