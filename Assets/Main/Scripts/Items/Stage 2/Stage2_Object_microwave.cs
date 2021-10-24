using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_Object_microwave : InteractiveObject
{
    [SerializeField] Image Microwave;
    [SerializeField] Image microwaveopen;
    [SerializeField] Image Hari;
    [SerializeField] Keypad keypad;
    public bool setactive=false;
    protected override void Start()
    {
        base.Start();
        condition = true;
    }
    protected override void Action()
    {
        if (keypad.already == true)
        {
            microwaveopen.gameObject.SetActive(true);
            Hari.gameObject.SetActive(false);
        }
        else
        setactive = true;
    }

    private void Update()
    {
        if (setactive)
        {
            Microwave.gameObject.SetActive(true);
        }
        else
            Microwave.gameObject.SetActive(false);
    }
}
