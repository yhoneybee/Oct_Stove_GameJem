using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MainLinker MainLinker;
    public string str;
    public void OnPointerEnter(PointerEventData eventData)
    {
        MainLinker.Title.text = str;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MainLinker.Title.text = "";
    }
}
