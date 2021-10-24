using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public PlayerSaveData player_save_data;

    public int HairCount
    {
        get => player_save_data.hair_count;
        set
        {
            // SetPlayerHair(); 함수 만들어서 실행시키기
            player_save_data.hair_count = value;
        }
    }

    // 인스펙터에서 파악하기 위한 변수
    [SerializeField] int hair_count;

    // 오브젝트 ID를 인덱스로 사용하는 배열 (해당 ID에 오브젝트를 갖고 있다면 1, 없다면 0)
    public bool[] object_id_arr
    { 
        get => player_save_data.object_id_arr;
        set
        {
            player_save_data.object_id_arr = value;
            for (int i = 0; i < player_save_data.object_id_arr.Length; i++)
                InventoryRenderer.Instance.Check(i);
        }
    }

    public int ending_case = 2;

    // 인스펙터에서 파악하기 위한 배열
    [SerializeField] bool[] show_array;

    void Start()
    {
    }

    void Update()
    {
        show_array = object_id_arr;
        hair_count = HairCount;
    }
}
