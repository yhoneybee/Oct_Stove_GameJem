using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour
{
    public Button Button;
    public Button door;
    public List<Sprite> sprites = new List<Sprite>();
    public Image Img;

    bool isButtonGotten = false;

    private void Start()
    {
        door.onClick.AddListener(() =>
        {
            if (StageManager.Instance.player_information.HairCount >= 6)
            {
                SceneManager.Instance.ChangeScene("Road");
            }
        });
        Button.onClick.AddListener(() =>
        {
            if (isButtonGotten)
            {
                Img.sprite = sprites[1];
                StageManager.Instance.player_information.HairCount++;
                StartCoroutine(EChangeSprite());
            }
            else
            {
                Img.sprite = sprites[0];
                GetComponent<RectTransform>().anchoredPosition = new Vector2(-414, 168.7f);
                isButtonGotten = true;
            }
        });
    }

    IEnumerator EChangeSprite()
    {
        yield return StartCoroutine(UIManager.Instance.EColoringUI(Img, Color.black, 3));
        Img.sprite = sprites[2];
        yield return StartCoroutine(UIManager.Instance.EColoringUI(Img, Color.white, 3));
    }
}
