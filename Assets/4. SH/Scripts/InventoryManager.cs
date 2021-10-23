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
    //  0.참치캔 1.단추   2.      3.      4.      5.      6.      7.      8.      9.    
        false,   false,  false,  false,  false,  false,  false,  false,  false,  false,
    };

    public List<Item> AllItem = new List<Item>();
}