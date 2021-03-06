using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; } = null;
    new Camera camera;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
    }

    public void ShakeCamera(float shake_time, float shake_power)
    {
        StartCoroutine(_ShakeCamera(shake_time, shake_power));
    }
    IEnumerator _ShakeCamera(float shake_time, float shake_power)
    {
        float current_time = Time.time;
        float translate_x, translate_y;

        while (Time.time - current_time < shake_time)
        {
            translate_x = Random.Range(-1, 2) * shake_power / 10;
            translate_y = Random.Range(-1, 2) * shake_power / 10;

            shake_power -= shake_power / 10;

            camera.transform.Translate(new Vector2(translate_x, translate_y));
            yield return new WaitForSeconds(0.01f);
            camera.transform.Translate(new Vector2(-translate_x, -translate_y));
        }
    }

    public void ZoomCamera(float zoom_size, float zoom_speed)
    {
        StartCoroutine(_ZoomCamera(zoom_size, zoom_speed));
    }
    IEnumerator _ZoomCamera(float zoom_size, float zoom_speed)
    {
        while (Mathf.Abs(camera.orthographicSize - zoom_size) > 0.01f)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, zoom_size, Time.deltaTime * zoom_speed);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void ZoomCamera(Vector2 pos, float zoom_size, float zoom_speed, float move_speed)
    {
        StartCoroutine(EZoomCamera(pos, zoom_size, zoom_speed, move_speed));
    }

    IEnumerator EZoomCamera(Vector2 pos, float zoom_size, float zoom_speed, float move_speed)
    {
        var wait = new WaitForSeconds(0.001f);

        while (Mathf.Abs(camera.orthographicSize - zoom_size) > 0.01f ||
            Vector2.Distance(camera.transform.position, pos) > 0.01f)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, zoom_size, Time.deltaTime * zoom_speed);
            camera.transform.position = Vector2.Lerp(camera.transform.position, pos, Time.deltaTime * move_speed);
            yield return wait;
        }
        camera.orthographicSize = zoom_size;
        camera.transform.position = pos;

        yield return null;
    }
}
