using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HideText : MonoBehaviour
{
    public TextMeshProUGUI Text;
    private void Start()
    {
        StartCoroutine(UIManager.Instance.EColoringUI(Text, Color.clear, 3));
    }
}
