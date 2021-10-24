using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InteractiveObject : MonoBehaviour
{
    Button button;

    public int ID;

    protected bool condition;
    protected virtual void Start()
    {
        button = GetComponent < Button>();

        button.onClick.AddListener(() => { Action(); });
    }

    protected abstract void Action();
}