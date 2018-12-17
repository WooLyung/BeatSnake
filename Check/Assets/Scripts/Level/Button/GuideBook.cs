using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideBook : MonoBehaviour {

    GameObject guides;
    GameObject BlackPanel;
    Image black;
    LevelManager manager;

    public Sprite Guide_Play, Guide_Map, Guide_Hard;

    public void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<LevelManager>();
        guides = GameObject.Find("Canvas").transform.Find("Guides").gameObject;
        BlackPanel = GameObject.Find("Canvas").transform.Find("BlackPanel2").gameObject;
        black = BlackPanel.GetComponent<Image>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("Guides") != null)
        {
            StartCoroutine("BlackOff");
        }
    }

    public void GuidePlay()
    {
        guides.transform.Find("GuideImg").GetComponent<Image>().sprite = Guide_Play;
    }

    public void GuideHard()
    {
        guides.transform.Find("GuideImg").GetComponent<Image>().sprite = Guide_Hard;
    }

    public void GuideMap()
    {
        guides.transform.Find("GuideImg").GetComponent<Image>().sprite = Guide_Map;
    }

    public void OpenGuide()
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
        guides.SetActive(true);
    }

    IEnumerator BlackOff()
    {
        yield return new WaitForSeconds(0.007f);
        black.color = new Color(0, 0, 0, 0);
        BlackPanel.SetActive(false);
        guides.SetActive(false);
        manager.canTouch = true;
    }
}
