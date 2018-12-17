using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour {

    void Start()
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f, Screen.width / 720f);
        if (gameObject.name == "TopText")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, +Screen.height / 1280f * 61f);
        }
        else if (gameObject.name == "Chapter")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, Screen.height / 2f + Screen.height / 1280f * 392f);
        }
        else if (gameObject.name == "NextPage")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -40f, Screen.height / 2f);
        }
        else if (gameObject.name == "PreviousPage")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 720f * 40f, Screen.height / 2f);
            gameObject.GetComponent<RectTransform>().localScale = new Vector2(-Screen.width / 720f, Screen.width / 720f);
        }
        else if (gameObject.name == "MapEditer")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 720f * 60f, Screen.height + Screen.height / 1280f * -45f);
        }
        else if (gameObject.name == "Option")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -55f, Screen.height + Screen.height / 1280f * -55f);
            gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f * 7 / 8f, Screen.width / 720f * 7 / 8f);
        }
        else if (gameObject.name == "GuideBook")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -140f, Screen.height + Screen.height / 1280f * -55f);
            gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f * 7 / 8f, Screen.width / 720f * 7 / 8f);
        }
    }
}
