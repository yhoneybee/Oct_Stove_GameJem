using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; } = null;
    public PlayerInformation player_information;
    public int stage_number;
    public int take_object_count;

    [Header("Stage 1 Objects")]
    public GameObject drawer;
    public GameObject mirror;
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
