using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MEui : MonoBehaviour {

    void Start ()
    {
        if (gameObject.name == "InputHeight")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f + 120 * Screen.width/720f, Screen.height / 2f);
        }
        else if (gameObject.name == "InputWidth")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f + -120, Screen.height / 2f);
        }
        else if (gameObject.name == "Load")
        {
            gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f + Screen.width / 720f * 145f, Screen.height / 2f + Screen.height / 1280f * -155f);
        }
        else
        {
            gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f, Screen.width / 720f);

            if (gameObject.name == "Text_Make")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 720f * 200f, Screen.height + Screen.height / 1280f * -500f);
            }
            else if (gameObject.name == "Text_Play")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -200f, Screen.height / 1280f * 500f);
            }
            else if (gameObject.name == "Background")
            {
                gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f, Screen.height / 1280f);
            }
            else if (gameObject.name == "Message")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, Screen.height / 1280f * 45f);
            }
            else if (gameObject.name == "Save")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -55f, Screen.height + Screen.height / 1280f * -55f);
                gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f * 7 / 8f, Screen.width / 720f * 7 / 8f);
            }
            else if (gameObject.name == "Remake")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -140f, Screen.height + Screen.height / 1280f * -55f);
                gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f * 7 / 8f, Screen.width / 720f * 7 / 8f);
            }
            else if (gameObject.name == "Guide")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -225f, Screen.height + Screen.height / 1280f * -55f);
                gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f * 7 / 8f, Screen.width / 720f * 7 / 8f);
            }
            else if (gameObject.name == "Save1")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, Screen.height / 2f + Screen.height / 1280f * 40f);
            }
            else if (gameObject.name == "Save2")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, Screen.height / 2f + Screen.height / 1280f * -40f);
            }
            else if (gameObject.name == "GuideText")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, Screen.height / 2f);
            }
            else if (gameObject.name == "MapSlider")
            {
                gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2f, Screen.height / 1280f * 160f);
            }
        }
    }

    public void Invisible()
    {
        transform.Find("Text").GetComponent<Text>().color = new Color(1, 1, 1, 0.75f);
        gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f, Screen.width / 720f);
    }

    public void Visible()
    {
        transform.Find("Text").GetComponent<Text>().color = new Color(1, 1, 1, 1);
        gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f * 1.2f, Screen.width / 720f * 1.2f);
    }
}
