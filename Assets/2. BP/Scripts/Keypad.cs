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
    public TextMeshProUGUI value;
    private bool delay;

    public void Input(int num)
    {
        if(delay == false)
        InputWord += Convert.ToString(num);
        StartCoroutine(check());
    }
    void quit()
    {
        Debug.Log("quit");
    }
    void correct()
    {
        Debug.Log("correct");
    }
    IEnumerator check()
    {
        value.text = Convert.ToString(InputWord);
        delay = true;
        if (PassWord.Length <= InputWord.Length)
        {
            if (PassWord == InputWord)
                correct();
            else
                quit();
            yield return new WaitForSeconds(0.3f);
            InputWord = null;
            value.text = Convert.ToString(InputWord);
        }
        yield return new WaitForSeconds(0.3f);
        delay = false;
    }
}
