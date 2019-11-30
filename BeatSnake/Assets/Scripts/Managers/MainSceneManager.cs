using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public Camera camera;
    private int camColorPattern = 0;
    private float camColor = 0;

    public RectTransform textTransform;
    private float textAngle = 0;

    public List<RectTransform> rects;
    private float scale = 1;

    private void Update()
    {
        CameraUpdate();
        TextUpdate();
        RectUpdate();

        if (Input.GetMouseButtonDown(0))
            GameStart();
    }

    private void RectUpdate()
    {
        scale += Time.deltaTime;
        if (scale >= 1.1f)
        {
            scale = 0.6f;
        }

        foreach (var element in rects)
        {
            element.localScale = new Vector3(scale, scale, 1);
        }
    }

    private void TextUpdate()
    {
        textAngle += Time.deltaTime * 2;
        if (textAngle >= Mathf.PI * 2)
        {
            textAngle = 0;
        }

        textTransform.eulerAngles = new Vector3(0, 0, (float)Mathf.Sin(textAngle) * 5 + 10);
    }

    private void CameraUpdate()
    {
        camColor += Time.deltaTime;
        if (camColor >= 1)
        {
            camColor = 0;
            camColorPattern = (camColorPattern + 1) % 6;
        }

        if (camColorPattern == 0)
        {
            camera.backgroundColor = new Color(0.8f, 0.3f, 0.3f + (camColor * 0.5f));
        }
        else if (camColorPattern == 1)
        {
            camera.backgroundColor = new Color(0.8f - (camColor * 0.5f), 0.3f, 0.8f);
        }
        else if (camColorPattern == 2)
        {
            camera.backgroundColor = new Color(0.3f, 0.3f + (camColor * 0.5f), 0.8f);
        }
        else if (camColorPattern == 3)
        {
            camera.backgroundColor = new Color(0.3f, 0.8f, 0.8f - (camColor * 0.5f));
        }
        else if (camColorPattern == 4)
        {
            camera.backgroundColor = new Color(0.3f + (camColor * 0.5f), 0.8f, 0.3f);
        }
        else if (camColorPattern == 5)
        {
            camera.backgroundColor = new Color(0.8f, 0.8f - (camColor * 0.5f), 0.3f);
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }
}
