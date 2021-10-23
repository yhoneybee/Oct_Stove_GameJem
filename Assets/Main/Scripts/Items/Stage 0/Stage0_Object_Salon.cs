using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage0_Object_Salon : InteractiveObject
{
    [SerializeField] GameObject help_window;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Action()
    {
        condition = StageManager.Instance.player_information.HairCount >= 8;

        if (condition)
        {
            CameraManager.Instance.ZoomCamera(3, 3);

            condition = false;
            Invoke("SceneChange", 2);
        }
        else
        {
            help_window.SetActive(true);
            Invoke("WindowDestroy", 2);
        }
    }

    void SceneChange()
    {
        SceneManager.Instance.ChangeScene("Salon");
    }
    private void WindowDestroy()
    {
        help_window.SetActive(false);
    }
}
