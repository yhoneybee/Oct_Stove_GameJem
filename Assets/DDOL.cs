using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDOL : MonoBehaviour
{
    public static DDOL ddol { get; private set; } = null;
    void Awake()
    {
        if (!ddol)
        {
            ddol = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {

    }

    void Update()
    {

    }
}
