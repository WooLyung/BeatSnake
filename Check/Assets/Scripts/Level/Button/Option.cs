using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour {

    GameObject options;
    GameObject BlackPanel;
    Image black;
    LevelManager manager;

    public void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<LevelManager>();
        options = GameObject.Find("Canvas").transform.Find("Options").gameObject;
        BlackPanel = GameObject.Find("Canvas").transform.Find("BlackPanel2").gameObject;
        black = BlackPanel.GetComponent<Image>();

        if (PlayerPrefs.GetInt("Option1") != 0 && PlayerPrefs.GetInt("Option1") != 1)
            PlayerPrefs.SetInt("Option1", 1);
        if (PlayerPrefs.GetInt("Option2") != 0 && PlayerPrefs.GetInt("Option2") != 1)
            PlayerPrefs.SetInt("Option2", 0);
        if (PlayerPrefs.GetInt("Option3") != 0 && PlayerPrefs.GetInt("Option3") != 1)
            PlayerPrefs.SetInt("Option3", 0);
    }

    public void Start()
    {

        if (PlayerPrefs.GetInt("Option2") == 0)
        {
            options.transform.Find("Option2").transform.Find("Text2").GetComponent<Text>().text = "꺼짐";
            options.transform.Find("Option2").transform.Find("Text2").GetComponent<Text>().color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            options.transform.Find("Option2").transform.Find("Text2").GetComponent<Text>().text = "켜짐";
            options.transform.Find("Option2").transform.Find("Text2").GetComponent<Text>().color = new Color(1, 1, 0.5f);
        }

        if (PlayerPrefs.GetInt("Option3") == 0)
        {
            options.transform.Find("Option3").transform.Find("Text2").GetComponent<Text>().text = "꺼짐";
            options.transform.Find("Option3").transform.Find("Text2").GetComponent<Text>().color = new Color(0.5f, 0.5f, 0.5f);
        }
        else
        {
            options.transform.Find("Option3").transform.Find("Text2").GetComponent<Text>().text = "켜짐";
            options.transform.Find("Option3").transform.Find("Text2").GetComponent<Text>().color = new Color(1, 1, 0.5f);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("Options") != null)
        {
            StartCoroutine("BlackOff");
        }
    }

    public void Option1()
    {
        string name = "Option1";

        if (PlayerPrefs.GetInt(name) == 0)
        {
            PlayerPrefs.SetInt(name, 1);
            options.transform.Find(name).transform.Find("Text2").GetComponent<Text>().text = "켜짐";
            options.transform.Find(name).transform.Find("Text2").GetComponent<Text>().color = new Color(1, 1, 0.5f);
        }
        else
        {
            PlayerPrefs.SetInt(name, 0);
            options.transform.Find(name).transform.Find("Text2").GetComponent<Text>().text = "꺼짐";
            options.transform.Find(name).transform.Find("Text2").GetComponent<Text>().color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    public void Option2()
    {
        string name = "Option2";

        if (PlayerPrefs.GetInt(name) == 0)
        {
            PlayerPrefs.SetInt(name, 1);
            options.transform.Find(name).transform.Find("Text2").GetComponent<Text>().text = "켜짐";
            options.transform.Find(name).transform.Find("Text2").GetComponent<Text>().color = new Color(1, 1, 0.5f);
        }
        else
        {
            PlayerPrefs.SetInt(name, 0);
            options.transform.Find(name).transform.Find("Text2").GetComponent<Text>().text = "꺼짐";
            options.transform.Find(name).transform.Find("Text2").GetComponent<Text>().color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    public void Option3()
    {
        string name = "Option3";

        if (PlayerPrefs.GetInt(name) == 0)
        {
            PlayerPrefs.SetInt(name, 1);
            options.transform.Find(name).transform.Find("Text2").GetComponent<Text>().text = "켜짐";
            options.transform.Find(name).transform.Find("Text2").GetComponent<Text>().color = new Color(1, 1, 0.5f);
        }
        else
        {
            PlayerPrefs.SetInt(name, 0);
            options.transform.Find(name).transform.Find("Text2").GetComponent<Text>().text = "꺼짐";
            options.transform.Find(name).transform.Find("Text2").GetComponent<Text>().color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    public void OnOption()
    {
        if (manager.canTouch)
        {
            StartCoroutine("BlackOn");
        }
    }

    IEnumerator BlackOn()
    {
        manager.canTouch = false;
        BlackPanel.SetActive(true);
        for (float i = 0; i <= 90; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }
        yield return new WaitForSeconds(0.3f);
        options.SetActive(true);
    }

    IEnumerator BlackOff()
    {
        yield return new WaitForSeconds(0.007f);
        black.color = new Color(0, 0, 0, 0);
        BlackPanel.SetActive(false);
        options.SetActive(false);
        manager.canTouch = true;
    }
}
