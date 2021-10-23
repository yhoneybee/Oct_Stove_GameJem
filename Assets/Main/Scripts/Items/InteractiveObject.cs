using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InteractiveObject : MonoBehaviour
{
    public enum ObjectKind
    {
        TakeObject,
        InteractiveObject
    }
    public ObjectKind object_kind;

    public Image image;
    public Sprite image_sprite;

    Button button;

    public int ID;
    public bool condition;
    void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent < Button>();

        button.onClick.AddListener(()=> { Action(condition); });
    }

    protected abstract void Action(bool condition);
}