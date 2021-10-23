using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryRenderer : MonoBehaviour
{
    public static InventoryRenderer Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public List<Image> slot_lt = new List<Image>();
    public void Check(int index)
    {
        if(StageManager.Instance.player_information.object_id_arr[index])
        {
            // 같은 코드
            //foreach (var o in InventoryManager.Instance.AllItem)
            //{
            //    if(o.itemIndex == index)
            //    {
            //        slot_lt[index].sprite = o.itemImage;
            //    }
            //}
            slot_lt[index].color  = new Color(1, 1, 1, 1);
            slot_lt[index].sprite = InventoryManager.Instance.AllItem.Find((o) => { return o.itemIndex == index; }).itemImage;
        }
    }
}
