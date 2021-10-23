using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; } = null;
    public PlayerInformation player_information;
    public int stage_number;
    public int take_object_count;

    public InteractiveObject[] interactive_objects;
    public List<InteractiveObject.Act> action_list = new List<InteractiveObject.Act>();

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        // 스테이지 번호에 따른 각 오브젝트 Action 추가
        switch (stage_number)
        {
            case 1:
                action_list.Add((condition) => {  });
                for (int i = 0; i < interactive_objects.Length; i++)
                    interactive_objects[i].Action += (condition) => { player_information.object_id_arr[interactive_objects[i].ID]++; };
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

    void Update()
    {

    }
}
