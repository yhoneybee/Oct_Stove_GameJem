using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage0_Object_Woman : InteractiveObject
{
    [SerializeField] RectTransform fade_rect_transform;

    [SerializeField] UnityEngine.UI.Image barikang;
    protected override void Start()
    {
        base.Start();

    }
    protected override void Action()
    {
        condition = true;
        if (condition)
        {
            barikang.gameObject.SetActive(true);
            barikang.rectTransform.localPosition = new Vector2(-844, -350);

            StartCoroutine(UIManager.Instance.EMovingUI(barikang, new Vector2(-844, -350 + 100), 5, true));

            StageManager.Instance.player_information.player_save_data.timer -= 30;

            CameraManager.Instance.ShakeCamera(5, 3f);
            StartCoroutine(FadeImage(fade_rect_transform.GetComponent<UnityEngine.UI.Image>(), new Color(1, 0, 0, 0.5f), new Color(0, 0, 0, 0)));

            Invoke("DestroyBarikang", 2);
        }
    }
    void DestroyBarikang()
    {
        barikang.gameObject.SetActive(false);
    }

    IEnumerator FadeImage(UnityEngine.UI.Image image, params Color[] colors)
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
}
