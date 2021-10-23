using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; } = null;
    public PlayerInformation player_information;

    public int timer;
    public int stage_number;
    public int take_object_count;
    public int need_hair_count;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
    }

    void Update()
    {
    }
}
