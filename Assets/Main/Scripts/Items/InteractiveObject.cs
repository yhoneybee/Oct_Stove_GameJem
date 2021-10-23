using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InteractiveObject : MonoBehaviour
{
    public Image image;
    public Sprite image_sprite;

    Button button;

    public int ID;
    public bool condition;
    protected virtual void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent < Button>();

        button.onClick.AddListener(() => { Action(); });
    }

    protected abstract void Action();
}