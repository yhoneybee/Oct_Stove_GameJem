using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ramen : MonoBehaviour
{
    [SerializeField] List<Image> sprites;
    bool[] color = { false, false,false,true};
    private void Start()
    {

    }

    private void Update()
    {
        for(int i = 0; i < 4; i++)
        {
            if (color[i] == false)
            {
                sprites[i].color = new Color(1, 0, 0);
            }
            else
                sprites[i].color = new Color(0, 1, 0);
        }
    }
    public void ClickEvent(int number)
    {
        if (color[number] == true)
        {
            color[number] = false;
        }
        else
            color[number] = true;
        if (color[0] == false && color[1] == true && color[2] == false && color[3] == false)
        {
            Debug.Log("정답이네요!");
        }
    }
}
