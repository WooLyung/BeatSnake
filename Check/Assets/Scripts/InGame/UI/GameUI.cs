using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {

	void Start () {

        gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f, Screen.width / 720f);

        if (gameObject.name == "Menu")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -55f, Screen.height + Screen.height / 1280f * -55f);
            gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f * 7/8f, Screen.width / 720f * 7 / 8f);
        }
        if (gameObject.name == "Regame")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -140f, Screen.height + Screen.height / 1280f * -55f);
            gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f * 7 / 8f, Screen.width / 720f * 7 / 8f);
        }
        if (gameObject.name == "Back")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -225f, Screen.height + Screen.height / 1280f * -55f);
            gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f * 7 / 8f, Screen.width / 720f * 7 / 8f);
        }
        if (gameObject.name == "Level")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 720f * 268f, Screen.height + Screen.height / 1280f * -162f);
        }
        if (gameObject.name == "Guide")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, Screen.height / 1280f * 60f);
        }
        if (gameObject.name == "ClearText")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, Screen.height / 2f);
        }
        if (gameObject.name == "Hint")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -50f, Screen.height / 1280f * 50f);
        }
        if (gameObject.name == "Tutorial")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, Screen.height / 2f);
        }
        if (gameObject.name == "Boast")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 720f * 180, Screen.height / 1280f * 30f);
        }
    }
}
