using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    private int hairCount;
    public int HairCount
    {
        get => hairCount;
        set
        {
            // SetPlayerHair(); 함수 만들어서 실행시키기
            hairCount = value;
        }
    }

    // 인스펙터에서 파악하기 위한 변수
    [SerializeField] int hair_count;

    // 오브젝트 ID를 인덱스로 사용하는 배열 (해당 ID에 오브젝트를 갖고 있다면 1, 없다면 0)
    public int[] object_id_arr { get; set; }

    // 인스펙터에서 파악하기 위한 배열
    [SerializeField] int[] show_array;

    void Start()
    {
        object_id_arr = new int[StageManager.Instance.take_object_count];
    }

    void Update()
    {
        show_array = object_id_arr;
        hair_count = HairCount;
    }
}
