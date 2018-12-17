using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    int width, height, nextIndex, stage;
    string chapter;

    Image black;
    public bool isClear = false;
    public int clearing = 0;

    Image blackPanel;
    Text clear;

    GameObject boast;
    Text boastText;

    private void Awake()
    {
        clearing = 0;
        black = GameObject.Find("BlackPanel").GetComponent<Image>();
        width = GameObject.Find("StageSetting").GetComponent<StageSetting>().width;
        height = GameObject.Find("StageSetting").GetComponent<StageSetting>().height;
        nextIndex = GameObject.Find("StageSetting").GetComponent<StageSetting>().nextIndex;
        chapter = GameObject.Find("StageSetting").GetComponent<StageSetting>().chapter;
        stage = GameObject.Find("StageSetting").GetComponent<StageSetting>().stage;
        blackPanel = GameObject.Find("BlackPanel2").GetComponent<Image>();
        clear = GameObject.Find("ClearText").GetComponent<Text>();

        boast = GameObject.Find("Canvas").transform.Find("Boast").gameObject;
        boastText = boast.transform.Find("Text").GetComponent<Text>();
    }

    private void Update()
    {
        if (isClear)
        {
            clearing = 1;
            isClear = false;
            StartCoroutine("End");
        }
        if (clearing == 2 && Input.GetMouseButtonDown(0) && Input.mousePosition.y >= 100 * Screen.height / 1280f)
        {
            StartCoroutine("BlackOn");
            clearing = 3;
        }
    }

    void ChangeColor(string name)
    {
        if (GameObject.Find(name).GetComponent<Tile>().condition == 0)
        {
            StartCoroutine("BeBlack", GameObject.Find(name));
            GameObject.Find(name).GetComponent<Tile>().condition = 1;
        }
        else if (GameObject.Find(name).GetComponent<Tile>().condition == 1)
        {
            StartCoroutine("BeWhite", GameObject.Find(name));
            GameObject.Find(name).GetComponent<Tile>().condition = 0;
        }
    }

    IEnumerator End()
    {
        PlayerPrefs.SetInt("Clear-" + chapter + stage, 1);
        if (GameObject.Find("HardMode") != null)
            PlayerPrefs.SetInt("HardClear-" + chapter + stage, 1);

        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                string name = "Tile[" + i + ";" + j + "]";
                if (GameObject.Find(name).GetComponent<Tile>().condition != 2)
                {
                    ChangeColor(name);
                }
            }
            yield return new WaitForSeconds(0.08f);
        }

        yield return new WaitForSeconds(0.015f);
        GameObject.Find("BlackPanel2").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        yield return new WaitForSeconds(0.05f);
        for (float i = 0; i <= 84; i+=4)
        {
            yield return new WaitForSeconds(0.01f);
            blackPanel.color = new Color(0, 0, 0, i/100);
        }
        yield return new WaitForSeconds(0.1f);
        boast.SetActive(true);
        for (float i = 0; i <= 100; i += 6)
        {
            yield return new WaitForSeconds(0.01f);
            clear.color = new Color(255, 255, 255, i / 100);
            boastText.color = new Color(255, 255, 255, i / 100);
        }
        clearing = 2;
    }

    IEnumerator BlackOn()
    {
        GameObject.Find("BlackPanel").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        for (float i = 0; i <= 110; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }
        SceneManager.LoadScene(nextIndex, LoadSceneMode.Single);
    }

    IEnumerator BeBlack(GameObject gameObject)
    {
        if (GameObject.Find("HardMode") != null)
        {
            SpriteRenderer white = gameObject.GetComponent<SpriteRenderer>();
            SpriteRenderer black = gameObject.transform.Find("black").GetComponent<SpriteRenderer>();

            GameObject countObj = GameObject.Find("Text[" + gameObject.GetComponent<Tile>().code[0] + ";" + gameObject.GetComponent<Tile>().code[1] + "]"); ;
            SpriteRenderer countSpr = countObj.GetComponent<SpriteRenderer>();

            for (float i = 0; i <= 110; i += 7)
            {
                yield return new WaitForSeconds(0.01f);
                black.color = new Color(255, 255, 255, i / 100);
                white.color = new Color(255, 255, 255, 1 - (i / 100));
                countSpr.color = new Color(i / 100f, i / 100f, i / 100f);
            }
            black.color = new Color(255, 255, 255, 1);
            white.color = new Color(255, 255, 255, 0);
            countSpr.color = new Color(1, 1, 1, 1);
        }
        else
        {
            SpriteRenderer white = gameObject.GetComponent<SpriteRenderer>();
            SpriteRenderer black = gameObject.transform.Find("black").GetComponent<SpriteRenderer>();

            for (float i = 0; i <= 110; i += 7)
            {
                yield return new WaitForSeconds(0.01f);
                black.color = new Color(255, 255, 255, i / 100);
                white.color = new Color(255, 255, 255, 1 - (i / 100));
            }
            black.color = new Color(255, 255, 255, 1);
            white.color = new Color(255, 255, 255, 0);
        }
    }

    IEnumerator BeWhite(GameObject gameObject)
    {
        if (GameObject.Find("HardMode") != null)
        {
            SpriteRenderer white = gameObject.GetComponent<SpriteRenderer>();
            SpriteRenderer black = gameObject.transform.Find("black").GetComponent<SpriteRenderer>();

            GameObject countObj = GameObject.Find("Text[" + gameObject.GetComponent<Tile>().code[0] + ";" + gameObject.GetComponent<Tile>().code[1] + "]"); ;
            SpriteRenderer countSpr = countObj.GetComponent<SpriteRenderer>();

            for (float i = 0; i <= 110; i += 7)
            {
                yield return new WaitForSeconds(0.01f);
                black.color = new Color(255, 255, 255, 1 - (i / 100));
                white.color = new Color(255, 255, 255, i / 100);
                countSpr.color = new Color(1 - i / 100f, 1 - i / 100f, 1 - i / 100f);
            }
            black.color = new Color(255, 255, 255, 0);
            white.color = new Color(255, 255, 255, 1);
            countSpr.color = new Color(0, 0, 0, 1);
        }
        else
        {
            SpriteRenderer white = gameObject.GetComponent<SpriteRenderer>();
            SpriteRenderer black = gameObject.transform.Find("black").GetComponent<SpriteRenderer>();

            for (float i = 0; i <= 110; i += 7)
            {
                yield return new WaitForSeconds(0.01f);
                black.color = new Color(255, 255, 255, 1 - (i / 100));
                white.color = new Color(255, 255, 255, i / 100);
            }
            black.color = new Color(255, 255, 255, 0);
            white.color = new Color(255, 255, 255, 1);
        }
    }
}

