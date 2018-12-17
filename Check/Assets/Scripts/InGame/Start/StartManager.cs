using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

    int width;
    int height;
    int[] condition;
    int[] type;
    int stage, nowIndex;
    string chapter;

    Image blackPanel;
    GameObject newTile;
    GameObject tiles;
    GameObject newText;

    public GameObject tile, text;
    public Sprite black;
    public bool canTouch = false;

    public Sprite black2, white2, black3, white3, black4, white4, pinWhite, pinBlack;

    float interval;

    private void Awake()
    {
        width = GameObject.Find("StageSetting").GetComponent<StageSetting>().width;
        height = GameObject.Find("StageSetting").GetComponent<StageSetting>().height;
        tiles = GameObject.Find("Tiles");
        condition = GameObject.Find("StageSetting").GetComponent<StageSetting>().condition;
        type = GameObject.Find("StageSetting").GetComponent<StageSetting>().type;
        blackPanel = GameObject.Find("BlackPanel").GetComponent<Image>();
        stage = GameObject.Find("StageSetting").GetComponent<StageSetting>().stage;
        nowIndex = GameObject.Find("StageSetting").GetComponent<StageSetting>().nowIndex;
        chapter = GameObject.Find("StageSetting").GetComponent<StageSetting>().chapter;
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Option2") == 1)
        {
            new GameObject("HardMode");
        }

        if (GameObject.Find("MePlayManager") != null)
        {
            GameObject.Find("Level").GetComponent<Text>().text = chapter;
        }
        else
        {
            GameObject.Find("Level").GetComponent<Text>().text = chapter + " " + stage;
        }
        GameObject.Find("ClearText").GetComponent<Text>().text = "성공!";
        GameObject.Find("Canvas").transform.Find("Boast").Find("Text").GetComponent<Text>().text = "페이스북에 글 올리기       ";

        StartCoroutine("BlackOff");
        CreateTile();
    }

    void CreateTile()
    {
        if (height * 5 < width * 7)
        {
            interval = 5.0f / width;
        }
        else
        {
            interval = 7.0f / height;
        }
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                newTile = Instantiate(tile);

                float size = interval / 5;
                newTile.transform.localScale = new Vector2(size, size);
                newTile.transform.parent = tiles.transform;
                newTile.name = "Tile[" + i + ";" + j + "]";

                Tile tileVar = newTile.GetComponent<Tile>();
                tileVar.code[0] = i;
                tileVar.code[1] = j;

                tileVar.type = type[i + j * width];
                if (tileVar.type == -1)
                {
                    newTile.GetComponent<SpriteRenderer>().sprite = pinWhite;
                    newTile.transform.Find("black").GetComponent<SpriteRenderer>().sprite = pinBlack;
                }
                else if (tileVar.type == 1)
                {
                    newTile.GetComponent<SpriteRenderer>().sprite = white2;
                    newTile.transform.Find("black").GetComponent<SpriteRenderer>().sprite = black2;
                }
                else if (tileVar.type == 2)
                {
                    newTile.GetComponent<SpriteRenderer>().sprite = white3;
                    newTile.transform.Find("black").GetComponent<SpriteRenderer>().sprite = black3;
                }
                else if (tileVar.type == 3)
                {
                    newTile.GetComponent<SpriteRenderer>().sprite = white4;
                    newTile.transform.Find("black").GetComponent<SpriteRenderer>().sprite = black4;
                }
           
                if (height * 5 < width * 7)
                {
                    float wid = interval * i + interval / 2.5f - 2.5f + 0.5f / width;
                    float hei = interval * j + interval / 2.5f - height * 2.5f / width + 0.5f / height;
                    newTile.transform.position = new Vector2(wid, hei);
                }
                else
                {
                    float wid = interval * i + interval / 2.5f - width * 3.5f / height + 0.5f / width;
                    float hei = interval * j + interval / 2.5f - 3.5f + 0.5f / height;
                    newTile.transform.position = new Vector2(wid, hei);
                }

                if (GameObject.Find("HardMode") != null)
                {
                    newText = Instantiate(text, newTile.transform.position + new Vector3(0, 0, -1), transform.rotation, GameObject.Find("HardMode").transform);
                    newText.name = "Text[" + i + ";" + j + "]";
                    newText.transform.localScale = newTile.transform.localScale * 0.4f;
                }
                
                newTile.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                newTile.transform.Find("black").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);

                if (condition[i + j * width] == PlayerPrefs.GetInt("Option3"))
                {
                    tileVar.condition = 0;
                }
                else if (condition[i + j * width] != PlayerPrefs.GetInt("Option3") && condition[i + j * width] != 2)
                {
                    tileVar.condition = 1;
                }
                else if (condition[i + j * width] == 2)
                {
                    tileVar.condition = 2;
                    newTile.transform.localScale = new Vector2(0, 0);
                }
            }
        }
        StartCoroutine("BlockAppearMain");
    }

    IEnumerator BlockAppearMain()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                StartCoroutine("BlockAppear", GameObject.Find("Tile[" + i + ";" + j + "]"));
            }
            yield return new WaitForSeconds(0.07f);
        }

        canTouch = true;
    }

    IEnumerator BlockAppear(GameObject gameobject)
    {
        if (height * 5 < width * 7)
        {
            interval = 5.0f / width;
        }
        else
        {
            interval = 7.0f / height;
        }
        float size = interval / 5;

        gameobject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
        gameobject.transform.localScale = new Vector2(size, size);
        for (float i = 0; i <= 110; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            if (gameobject.GetComponent<Tile>().condition == 0)
                gameobject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, i / 100);
            else if (gameobject.GetComponent<Tile>().condition == 1)
                gameobject.transform.Find("black").GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, i / 100);

            if (GameObject.Find("HardMode") != null)
            {
                GameObject countObj = GameObject.Find("Text[" + gameobject.GetComponent<Tile>().code[0] + ";" + gameobject.GetComponent<Tile>().code[1] + "]");
                if (gameobject.GetComponent<Tile>().condition == 0)
                    countObj.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, i / 100);
                else if (gameobject.GetComponent<Tile>().condition == 1)
                    countObj.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, i / 100);
            }
        }
        yield return new WaitForSeconds(0.6f);
    }
    
    IEnumerator BlackOff()
    {
        yield return new WaitForSeconds(0.4f);
        for (float i = 100; i >= -10; i -= 3)
        {
            yield return new WaitForSeconds(0.007f);
            blackPanel.color = new Color(0, 0, 0, i / 100);
        }
        GameObject.Find("BlackPanel").GetComponent<RectTransform>().localScale = new Vector2(0, 0);
        GameObject.Find("BlackPanel2").GetComponent<RectTransform>().localScale = new Vector2(0, 0);
    }
}
