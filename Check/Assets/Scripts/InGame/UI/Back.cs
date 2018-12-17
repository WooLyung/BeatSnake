using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour {

    public int[ , ] backTile = new int[10, 50];
    int width, latelyIndex;

    GameObject countObj;
    SpriteRenderer countSpr;

    private void Awake()
    {
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0.35f);
        width = GameObject.Find("StageSetting").GetComponent<StageSetting>().width;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                backTile[i, j] = 0;
            }
        }
    }

    public void TileBack()
    {
        if (GameObject.Find("StageClear").GetComponent<StageClear>().clearing == 0)
        {
            BAck();
        }
    }

    public void BAck()
    {

        latelyIndex = -1;

        for (int i = 0; i < 10; i++)
        {
            if (backTile[i, 0] != 0)
            {
                latelyIndex = i;
            }
        }
        if (latelyIndex == 0)
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0.35f);

        for (int i = 0; i < 50 && latelyIndex >= 0 && backTile[latelyIndex, i] != 0; i++)
        {
            int codeX = (backTile[latelyIndex, i] - 1) % width;
            int codeY = (backTile[latelyIndex, i] - 1) / width;

            string Name = "Tile[" + codeX + ";" + codeY + "]";
            ChangeColor(Name);

            backTile[latelyIndex, i] = 0;
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
