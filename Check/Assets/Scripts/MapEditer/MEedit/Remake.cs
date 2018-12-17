using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Remake : MonoBehaviour {

    GameObject BlackPanel;
    GameObject BlackPanel2;
    public GameObject MEdata;

    MEeditManager manager;

    Image black;
    Image black2;

    public void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<MEeditManager>();
        BlackPanel = GameObject.Find("BlackPanel");
        black = BlackPanel.GetComponent<Image>();
        BlackPanel2 = GameObject.Find("BlackPanel2");
        black2 = BlackPanel2.GetComponent<Image>();
    }

    public void ReMake()
    {
        StartCoroutine("BlackOn");
    }

    IEnumerator BlackOn()
    {
        BlackPanel.SetActive(true);
        GameObject newObj = Instantiate(MEdata);
        newObj.name = "MEdata";
        newObj.GetComponent<MEdata>().data_width = manager.width;
        newObj.GetComponent<MEdata>().data_height = manager.height;
        manager.canTouch = false;
        for (float i = 0; i <= 110; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }
        SceneManager.LoadScene(63, LoadSceneMode.Single);
    }
}
