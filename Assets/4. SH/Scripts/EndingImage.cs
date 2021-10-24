using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingImage : MonoBehaviour
{
    public List<GameObject> happy_img;
    public List<GameObject> bald_img;
    public List<GameObject> normal_img;

    public Image Fade;

    public List<GameObject> GetImgList(int index)
    {
        return index switch
        {
            0 => happy_img,
            1 => bald_img,
            2 => normal_img,
            _ => null,
        };
    }

    void Start()
    {
        ResetImage();
        ImageRender(GetImgList(StageManager.Instance.player_information.ending_case));
    }

    void ResetImage()
    {
        for (int i = 0; i < happy_img.Count; i++)
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

        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetActive(true);
            yield return waitTime;
        }

        yield return StartCoroutine(UIManager.Instance.EColoringUI(Fade, Color.black, 3));
        Debug.Log("SceneChange");
        SceneManager.Instance.ChangeScene("Main");
        ResetImage();
    }
}
