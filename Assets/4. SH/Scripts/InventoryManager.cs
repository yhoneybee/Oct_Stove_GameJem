using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    public List<bool> item_lt = new List<bool>()
    {
    //  1.     2.     3.     4.     5.     6.     7.     8.     9.     10.
        false, false, false, false, false, false, false, false, false, false,
    };

    // Update is called once per frame
    void Update()
    {

    }
}
