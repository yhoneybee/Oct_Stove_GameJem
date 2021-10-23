using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public List<Item> AllItem = new List<Item>();

    // Update is called once per frame
    void Update()
    {

    }
}
