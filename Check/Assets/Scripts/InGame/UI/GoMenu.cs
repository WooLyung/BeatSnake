using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoMenu : MonoBehaviour {

    Image black;
    public GameObject chapterData;
    string chapter;

    private void Awake()
    {
        black = GameObject.Find("BlackPanel").GetComponent<Image>();
        chapter = GameObject.Find("StageSetting").GetComponent<StageSetting>().chapter;
    }

    public void Menu()
    {
        if (GameObject.Find("StageClear").GetComponent<StageClear>().clearing == 0)
        {
            StartCoroutine("BlackOn");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (GameObject.Find("StageClear").GetComponent<StageClear>().clearing == 0)
            {
                StartCoroutine("BlackOn");
            }
        }
    }

    IEnumerator BlackOn()
    {
        if (GameObject.Find("MePlayManager") == null)
        {
            GameObject newObject = Instantiate(chapterData);
            newObject.GetComponent<ChapterData>().chapter = chapter;
            newObject.name = "ChapterData";
        }

        GameObject.Find("StageClear").GetComponent<StageClear>().clearing = 3;
        GameObject.Find("BlackPanel").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        for (float i = 0; i <= 110; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
