using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Keypad : MonoBehaviour
{
    [SerializeField] string PassWord;
    [SerializeField] string InputWord;
    [SerializeField] List<Image> btn;
    [SerializeField] Stage2_Object_microwave microwave;
    [SerializeField] Image microwaveopen;
    public TextMeshProUGUI value;
    private bool delay;
    public bool already = false;

    public void Input(int num)
    {
        if(delay == false)
        {
            if(InputWord.Length<3)
            StartCoroutine(Coloring(num));
            InputWord += Convert.ToString(num);
        }
        StartCoroutine(check());
    }
    IEnumerator Coloring(int num)
    {
        UIManager.Instance.StartCoroutine(UIManager.Instance.EColoringUI(btn[num-1], new Color(0, 0, 0, 0.3f), 20));
        yield return new WaitForSeconds(0.3f);
        UIManager.Instance.StartCoroutine(UIManager.Instance.EColoringUI(btn[num-1], new Color(0, 0, 0, 0), 30));
    }
    void quit()
    {
        microwave.setactive = false;
        InputWord = "";
    }
    void correct()
    {
        microwaveopen.gameObject.SetActive(true);
        microwave.setactive = false;
        already = true;
    }
    IEnumerator check()
    {
        //value.text = Convert.ToString(InputWord);
        delay = true;
        if (PassWord.Length <= InputWord.Length)
        {
            if (PassWord == InputWord)
                correct();
            else
            {
                delay = false;
                quit();
            }
            yield return new WaitForSeconds(0.3f);
            InputWord = "";
            //value.text = Convert.ToString(InputWord);
        }
        yield return new WaitForSeconds(0.3f);
        delay = false;
    }
}
