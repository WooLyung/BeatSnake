using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour {

    void Start()
    {

        if (gameObject.name == "WhitePanel")
        {
            gameObject.GetComponent<Transform>().localScale = new Vector2((Screen.width / (float)Screen.height) / (720f / 1280f), 1);
        }
        else
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f, Screen.width / 720f);
            if (gameObject.name == "Text")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, Screen.height / 2f + Screen.height / 1280f * -75f);
            }
            else if (gameObject.name == "Logo")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, Screen.height / 2f + Screen.height / 1280f * 130f);
            }
            else if (gameObject.name == "Version")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -510f, Screen.height / 1280f * 30f);
            }
        }
    }
}