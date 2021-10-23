using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingImage : MonoBehaviour
{
    public List<GameObject> happy_img;
    public List<GameObject> bald_img;
    public List<GameObject> normal_img;

    void Start()
    {
        ResetImage();
        ImageRender(normal_img);
    }

    void ResetImage()
    {
        for(int i = 0; i < happy_img.Count; i++)
            happy_img[i].SetActive(false);
        for (int i = 0; i < bald_img.Count; i++)
            bald_img[i].SetActive(false);
        for (int i = 0; i < 4; i++)
            normal_img[i].SetActive(false);
    }

    void ImageRender(List<GameObject> list)
    {
        StartCoroutine(UpdateImage(list));
    }

    IEnumerator UpdateImage(List<GameObject> list)
    {
        var waitTime = new WaitForSeconds(2f);

        for(int i = 0; i < list.Count; i++)
        {
            list[i].SetActive(true);
            yield return waitTime;
        }

        yield return new WaitForSeconds(7f);
        Debug.Log("SceneChange");
        ResetImage();
    }
}