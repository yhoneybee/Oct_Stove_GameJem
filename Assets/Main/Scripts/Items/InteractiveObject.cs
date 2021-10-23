using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour
{
    public enum ObjectKind
    {
        TakeObject,
        InteractiveObject
    }
    public ObjectKind object_kind;

    public Image image;
    public Sprite image_sprite;

    public int ID;

    public delegate void Act(bool condition);
    public Act Action;

    //player.id_array[ID] > 0로 인자 넘겨주기
    public void ObjectAction(bool able = true)
    {
            Action(able && Action != null);
    }
}