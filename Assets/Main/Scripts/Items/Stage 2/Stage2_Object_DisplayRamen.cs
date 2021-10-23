using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2_Object_DisplayRamen : InteractiveObject
{
    [SerializeField] Image btn;
    public bool puzzling;
    protected override void Start()
    {
        base.Start();
        condition = true;
    }
    protected override void Action()
    {
        CameraManager.Instance.ZoomCamera(new Vector2(7.5f, 2.6f), 1, 4, 4);
        puzzling = true;
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
        puzzling = false;
    }

}
