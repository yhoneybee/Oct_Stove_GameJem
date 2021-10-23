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
    /// GraphicŬ������ ��ӹ޴� ��� UI�� �����ϼ��ִ� �ڷ�ƾ�Դϴ�
    /// ��ư�� btn.targetGraphic���� �θ�����~
    /// </summary>
    /// <typeparam name="T">Graphic�� ��ӹ޴� ����</typeparam>
    /// <param name="ui">������ UI</param>
    /// <param name="change_pos">���� ����</param>
    /// <param name="isLerp">Lerp�� ó���Ұ��ΰ�? false��� MoveTowards�� ó����</param>
    /// <param name="move_speed">�����̴� �ӵ�</param>
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
    /// Lerp�� Color�� �����ϴ� �ڷ�ƾ�Դϴ�
    /// ��ư�� btn.targetGraphic���� �θ�����~
    /// </summary>
    /// <typeparam name="T">Graphic�� ��ӹ޴� ����</typeparam>
    /// <param name="ui">���� �ٲ� UI</param>
    /// <param name="change_color">�ٲ� ��</param>
    /// <param name="change_speed">�ٲٴ� �ӵ�</param>
    /// <returns></returns>
    public IEnumerator EColoringUI<T>(T ui, Color change_color, float change_speed)
        where T : Graphic
    {
        var wait = new WaitForSeconds(0.0001f);

        while (Mathf.Abs(ui.color.r - change_color.r) + 
            Mathf.Abs(ui.color.g - change_color.g) + 
            Mathf.Abs(ui.color.b - change_color.b) +
            Mathf.Abs(ui.color.a - change_color.a) > 0.005f)
        {
            ui.color = Color.Lerp(ui.color, change_color, Time.deltaTime * change_speed);
            yield return wait;
        }
        ui.color = change_color;

        yield return null;
    }

    /// <summary>
    /// UI�� ũ�⸦ �ٲٴ� �ڷ�ƾ�Դϴ�
    /// ��ư�� btn.targetGraphic���� �θ�����~
    /// </summary>
    /// <typeparam name="T">Graphic�� ��ӹ޴� ����</typeparam>
    /// <param name="ui">ũ�⸦ �ٲ� UI</param>
    /// <param name="change_scale">�ٲ� ũ��</param>
    /// <param name="change_speed">�ٲٴ� �ӵ�</param>
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
