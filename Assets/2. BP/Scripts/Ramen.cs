using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ramen : MonoBehaviour
{
    [SerializeField] List<Image> sprites;
    bool[] color = { false, false, false, true };
    bool correct = false;
    public Image ramenvinel;
    Transform ramenpos;
    private void Start()
    {
        ramenpos = ramenvinel.gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        for (int i = 0; i < 4; i++)
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
        if (correct == false)
        {

            if (color[number] == true)
            {
                color[number] = false;
            }
            else
                color[number] = true;
            if (color[0] == false && color[1] == true && color[2] == false && color[3] == false)
            {
                correct = true;
                StartCoroutine(UIManager.Instance.EMovingUI(ramenvinel, new Vector2(700, -300), 3, true));
            }
        }
    }
}
