using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Graphic클래스를 상속받는 모든 UI를 움직일수있는 코루틴입니다
    /// 버튼은 Graphic을 상속받지 않더군요...
    /// </summary>
    /// <typeparam name="T">Graphic을 상속받는 형식</typeparam>
    /// <param name="ui">움직일 UI</param>
    /// <param name="change_pos">도착 지점</param>
    /// <param name="isLerp">Lerp로 처리할것인가? false라면 MoveTowards로 처리함</param>
    /// <param name="move_speed">움직이는 속도</param>
    /// <returns></returns>
    public IEnumerator EMovingUI<T>(T ui, Vector2 change_pos, float move_speed, bool isLerp = false)
        where T : Graphic
    {
        var wait = new WaitForSeconds(0.0001f);
        var uiRTf = ui.GetComponent<RectTransform>();

        while (Vector2.Distance(uiRTf.anchoredPosition, change_pos) > 0.1f)
        {
            if (isLerp) uiRTf.anchoredPosition = Vector2.Lerp(uiRTf.anchoredPosition, change_pos, Time.deltaTime * move_speed);
            else uiRTf.anchoredPosition = Vector2.MoveTowards(uiRTf.anchoredPosition, change_pos, Time.deltaTime * move_speed);
            yield return wait;
        }
        uiRTf.anchoredPosition = change_pos;

        yield return null;
    }

    /// <summary>
    /// Lerp로 Color를 수정하는 코루틴입니다
    /// </summary>
    /// <typeparam name="T">Graphic을 상속받는 형식</typeparam>
    /// <param name="ui">색을 바꿀 UI</param>
    /// <param name="change_color">바꿀 색</param>
    /// <param name="change_speed">바꾸는 속도</param>
    /// <returns></returns>
    public IEnumerator EColoringUI<T>(T ui, Color change_color, float change_speed)
        where T : Graphic
    {
        var wait = new WaitForSeconds(0.0001f);

        while (ui.color.r >= change_color.r &&
            ui.color.g >= change_color.g &&
            ui.color.b >= change_color.b &&
            ui.color.a >= change_color.a)
        {
            ui.color = Color.Lerp(ui.color, change_color, Time.deltaTime * change_speed);
            yield return wait;
        }
        ui.color = change_color;

        yield return null;
    }

    /// <summary>
    /// UI의 크기를 바꾸는 코루틴입니다
    /// </summary>
    /// <typeparam name="T">Graphic을 상속받는 형식</typeparam>
    /// <param name="ui">크기를 바꿀 UI</param>
    /// <param name="change_scale">바꿀 크기</param>
    /// <param name="change_speed">바꾸는 속도</param>
    /// <param name="isLerp"></param>
    /// <returns></returns>
    public IEnumerator EScalingUI<T>(T ui, Vector2 change_scale, float change_speed, bool isLerp = false)
        where T : Graphic
    {
        var wait = new WaitForSeconds(0.0001f);
        var uiRTf = ui.GetComponent<RectTransform>();

        while (Vector2.Distance(uiRTf.localScale, change_scale) > 0.1f)
        {
            if (isLerp) uiRTf.localScale = Vector3.Lerp(uiRTf.localScale, change_scale, Time.deltaTime * change_speed);
            else uiRTf.localScale = Vector3.MoveTowards(uiRTf.localScale, change_scale, Time.deltaTime * change_speed);
            yield return wait;
        }
        uiRTf.localScale = change_scale;

        yield return null;
    }
}
