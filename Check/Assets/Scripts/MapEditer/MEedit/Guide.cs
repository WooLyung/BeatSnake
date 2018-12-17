using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guide : MonoBehaviour {

    GameObject guideText;
    GameObject BlackPanel;
    GameObject BlackPanel2;

    MEeditManager manager;

    Image black;
    Image black2;

    public void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<MEeditManager>();
        guideText = GameObject.Find("Canvas").transform.Find("GuideText").gameObject;
        BlackPanel = GameObject.Find("BlackPanel");
        black = BlackPanel.GetComponent<Image>();
        BlackPanel2 = GameObject.Find("BlackPanel2");
        black2 = BlackPanel2.GetComponent<Image>();
    }

    public void OnGuide()
    {
        BlackPanel2.SetActive(true);
        StartCoroutine("Black2On");
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonUp(0) && GameObject.Find("GuideText") != null)
        {
            manager.canTouch = true;
            black2.color = new Color(1, 1, 1, 0);
            BlackPanel2.SetActive(false);
            guideText.SetActive(false);
        }
    }

    IEnumerator Black2On()
    {
        manager.canTouch = false;
        for (float i = 0; i <= 90; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black2.color = new Color(0, 0, 0, i / 100);
        }
        yield return new WaitForSeconds(0.3f);
        guideText.SetActive(true);
    }
}
