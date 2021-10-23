using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; } = null;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string scene_name)
    {
        LoadScene(scene_name);
    }
}
