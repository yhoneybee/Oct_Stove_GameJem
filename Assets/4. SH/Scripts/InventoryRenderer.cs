using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryRenderer : MonoBehaviour
{
    public List<Image> slot_lt = new List<Image>();

    void Start()
    {
        //StageManager.Instance.player_information.object_id_arr[1] = 1;
    }
    void Check(int index)
    {
        if(InventoryManager.Instance.item_lt[index])
        {
            //foreach (var o in InventoryManager.Instance.AllItem)
            //{
            //    if(o.itemIndex == index)
            //    {
            //        slot_lt[index].sprite = o.itemImage;
            //    }
            //}
            slot_lt[index].sprite = InventoryManager.Instance.AllItem.Find((o) => { return o.itemIndex == index; }).itemImage;
        }
    }
}
