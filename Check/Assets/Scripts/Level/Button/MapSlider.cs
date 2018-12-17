using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSlider : MonoBehaviour
{

    LevelManager manager;

    private void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<LevelManager>();
    }

    private void Start()
    {
        GetComponent<Slider>().maxValue = 0;
        if (PlayerPrefs.GetInt("Clear-Black20") == 1)
        {
            GetComponent<Slider>().maxValue = 1;
        }
        if (PlayerPrefs.GetInt("Clear-Green20") == 1)
        {
            GetComponent<Slider>().maxValue = 2;
        }
        if (PlayerPrefs.GetInt("Clear-Blue20") == 1)
        {
            GetComponent<Slider>().maxValue = 3;
        }
        if (PlayerPrefs.GetInt("Clear-Yellow20") == 1)
        {
            GetComponent<Slider>().maxValue = 4;
        }
        if (PlayerPrefs.GetInt("Clear-Red20") == 1)
        {
            GetComponent<Slider>().maxValue = 5;
        }
        if (PlayerPrefs.GetInt("Clear-Purple20") == 1)
        {
            GetComponent<Slider>().maxValue = 6;
        }
    }

    private void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            if (manager.chapter == "Black")
            {
                GetComponent<Slider>().value = 0;
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0.15f, 0.15f, 0.15f, 1);
            }
            else if (manager.chapter == "Green")
            {
                GetComponent<Slider>().value = 1;
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0, 0.38f, 0, 1);
            }
            else if (manager.chapter == "Blue")
            {
                GetComponent<Slider>().value = 2;
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0, 0, 0.38f, 1);
            }
            else if (manager.chapter == "Yellow")
            {
                GetComponent<Slider>().value = 3;
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0.38f, 0.38f, 0, 1);
            }
            else if (manager.chapter == "Red")
            {
                GetComponent<Slider>().value = 4;
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0.38f, 0, 0, 1);
            }
            else if (manager.chapter == "Purple")
            {
                GetComponent<Slider>().value = 5;
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0.38f, 0, 0.38f, 1);
            }
            else if (manager.chapter == "Orange")
            {
                GetComponent<Slider>().value = 6;
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0.38f, 0.19f, 0, 1);
            }
        }
        else
        {
            if (GetComponent<Slider>().value == 0)
            {
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0.15f, 0.15f, 0.15f, 1);
            }
            else if (GetComponent<Slider>().value == 1)
            {
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0, 0.38f, 0, 1);
            }
            else if (GetComponent<Slider>().value == 2)
            {
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0, 0, 0.38f, 1);
            }
            else if (GetComponent<Slider>().value == 3)
            {
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0.38f, 0.38f, 0, 1);
            }
            else if (GetComponent<Slider>().value == 4)
            {
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0.38f, 0, 0, 1);
            }
            else if (GetComponent<Slider>().value == 5)
            {
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0.38f, 0, 0.38f, 1);
            }
            else if (GetComponent<Slider>().value == 6)
            {
                GameObject.Find("Handle").GetComponent<Image>().color = new Color(0.38f, 0.19f, 0, 1);
            }
        }
    }
}