using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_Object_DisplayRamen : InteractiveObject
{
    [SerializeField] Image btn;
    public bool puzzling;
    bool delay;
    protected override void Start()
    {
        base.Start();
        condition = true;
    }
    protected override void Action()
    {
        if (delay == false)
        {
            puzzling = true;
            delay = true;
            CameraManager.Instance.ZoomCamera(new Vector2(7.5f, 2.6f), 1, 4, 4);
            StartCoroutine(delaya());
        }
    }
    private void Update()
    {
        if (puzzling)
        {
            btn.raycastTarget = false;
        }
        else
        {
            btn.raycastTarget = true;

        }
    }
    public void quit()
    {
        if (puzzling == true&& delay == false)
        {
            puzzling = false;
            delay = true;
            CameraManager.Instance.ZoomCamera(new Vector2(0, 0), 5, 4, 4);
            StartCoroutine(delaya());
        }
    }
    IEnumerator delaya()
    {
        yield return new WaitForSeconds(2);
        delay = false;
    }
}
