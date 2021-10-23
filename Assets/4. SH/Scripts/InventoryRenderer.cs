using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryRenderer : MonoBehaviour
{
    public List<Image> slot_lt = new List<Image>();
    public List<Image> img_lt  = new List<Image>();

    Item item = new Item();

    // Start is called before the first frame update
    void Start()
    {
        img_lt[item.itemIndex].sprite = item.itemImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
