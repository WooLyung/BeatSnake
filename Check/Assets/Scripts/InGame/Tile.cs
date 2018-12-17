using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tile : MonoBehaviour {

    public int[] code = new int[2];
    public int condition = 0;
    public int type = 0;
    public int count = 3;

    int[, ] backTile = new int[10, 50];
    int latelyIndex;

    public Sprite white;
    public Sprite black;

    int width, height, clearing;
    bool canTouch;

    public bool onMouse = false;

    private void Awake()
    {
        width = GameObject.Find("StageSetting").GetComponent<StageSetting>().width;
        height = GameObject.Find("StageSetting").GetComponent<StageSetting>().height;
        backTile = GameObject.Find("Back").GetComponent<Back>().backTile;
    }

    void OnMouseEnter()
    {
        onMouse = true;
    }

    void OnMouseExit()
    {
        onMouse = false;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(2) && onMouse && Input.touchCount == 0)
        {
            latelyIndex = -1;

            for (int i = 0; i < 10; i++)
            {
                if (backTile[i, 0] != 0)
                {
                    latelyIndex = i;
                }
            }
            if (latelyIndex == 9)
            {
                latelyIndex = 8;
                for (int i = 1; i < 10; i++)
                {
                    for (int j = 0; j < 50; j++)
                        backTile[i - 1, j] = backTile[i, j];
                }
                for (int j = 0; j < 50; j++)
                    backTile[9, j] = 0;
            }

            name = "Tile[" + (code[0]) + ";" + (code[1]) + "]";
            ChangeColor(name);
        }
    }

    void OnMouseUp()
    {
        clearing = GameObject.Find("StageClear").GetComponent<StageClear>().clearing;

        if (GameObject.Find("Tutorial") == null)
        {
            canTouch = GameObject.Find("StartManager").GetComponent<StartManager>().canTouch;
        }
        else if (GameObject.Find("StageSetting").GetComponent<StageSetting>().stage == 1)
        {
            canTouch = GameObject.Find("StartManager").GetComponent<Tutorial1>().canTouch;
        }
        else
        {
            canTouch = GameObject.Find("StartManager").GetComponent<Tutorial2>().canTouch;
        }

        if (clearing == 0 && canTouch)
        {
            if (count > 0)
            {
                latelyIndex = -1;

                for (int i = 0; i < 10; i++)
                {
                    if (backTile[i, 0] != 0)
                    {
                        latelyIndex = i;
                    }
                }
                if (latelyIndex == 9)
                {
                    latelyIndex = 8;
                    for (int i = 1; i < 10; i++)
                    {
                        for (int j = 0; j < 50; j++)
                            backTile[i - 1, j] = backTile[i, j];
                    }
                    for (int j = 0; j < 50; j++)
                        backTile[9, j] = 0;
                }

                if (GameObject.Find("HardMode") != null)
                {
                    if (type != 3 && type != -1)
                    {
                        count--;

                        if (count == 0)
                            GameObject.Find("Text[" + (code[0]) + ";" + (code[1]) + "]").GetComponent<SpriteRenderer>().sprite = GameObject.Find("Text[" + (code[0]) + ";" + (code[1]) + "]").GetComponent<LockSprite>().lock1;
                        if (count == 1)
                            GameObject.Find("Text[" + (code[0]) + ";" + (code[1]) + "]").GetComponent<SpriteRenderer>().sprite = GameObject.Find("Text[" + (code[0]) + ";" + (code[1]) + "]").GetComponent<LockSprite>().lock2;
                        if (count == 2)
                            GameObject.Find("Text[" + (code[0]) + ";" + (code[1]) + "]").GetComponent<SpriteRenderer>().sprite = GameObject.Find("Text[" + (code[0]) + ";" + (code[1]) + "]").GetComponent<LockSprite>().lock3;
                    }
                }

                Reverse();
                GameClear();
            }
        }
    }

    void Reverse()
    {
        if (condition != 2)
        {
            string name;
            if (type == 0)
            {
                for (int i = 0; i < 50; i++)
                {
                    backTile[latelyIndex + 1, i] = 0;
                }
                GameObject.Find("Back").GetComponent<Image>().color = new Color(255, 255, 255, 1);

                if (code[0] > 0)
                {
                    name = "Tile[" + (code[0] - 1) + ";" + (code[1]) + "]";
                    ChangeColor(name);
                }
                if (code[0] < width - 1)
                {
                    name = "Tile[" + (code[0] + 1) + ";" + (code[1]) + "]";
                    ChangeColor(name);
                }
                if (code[1] > 0)
                {
                    name = "Tile[" + (code[0]) + ";" + (code[1] - 1) + "]";
                    ChangeColor(name);
                }
                if (code[1] < height - 1)
                {
                    name = "Tile[" + (code[0]) + ";" + (code[1] + 1) + "]";
                    ChangeColor(name);
                }
            }
            else if (type == 1)
            {
                for (int i = 0; i < 50; i++)
                {
                    backTile[latelyIndex + 1, i] = 0;
                }
                GameObject.Find("Back").GetComponent<Image>().color = new Color(255, 255, 255, 1);

                if (code[0] > 0)
                {
                    name = "Tile[" + (code[0] - 1) + ";" + (code[1]) + "]";
                    ChangeColor(name);
                }
                if (code[0] < width - 1)
                {
                    name = "Tile[" + (code[0] + 1) + ";" + (code[1]) + "]";
                    ChangeColor(name);
                }
                if (code[1] > 0)
                {
                    name = "Tile[" + (code[0]) + ";" + (code[1] - 1) + "]";
                    ChangeColor(name);
                }
                if (code[1] < height - 1)
                {
                    name = "Tile[" + (code[0]) + ";" + (code[1] + 1) + "]";
                    ChangeColor(name);
                }
                name = "Tile[" + (code[0]) + ";" + (code[1] ) + "]";
                ChangeColor(name);
            }
            else if (type == 2)
            {
                for (int i = 0; i < 50; i++)
                {
                    backTile[latelyIndex + 1, i] = 0;
                }
                GameObject.Find("Back").GetComponent<Image>().color = new Color(255, 255, 255, 1);

                if (code[0] > 0 && code[1] > 0)
                {
                    name = "Tile[" + (code[0] - 1) + ";" + (code[1] - 1) + "]";
                    ChangeColor(name);
                }
                if (code[0] < width - 1 && code[1] > 0)
                {
                    name = "Tile[" + (code[0] + 1) + ";" + (code[1] - 1) + "]";
                    ChangeColor(name);
                }
                if (code[1] < height - 1 && code[0] > 0)
                {
                    name = "Tile[" + (code[0] - 1) + ";" + (code[1] + 1) + "]";
                    ChangeColor(name);
                }
                if (code[1] < height - 1 && code[0] < width - 1)
                {
                    name = "Tile[" + (code[0] + 1) + ";" + (code[1] + 1) + "]";
                    ChangeColor(name);
                }
            }
            else if (type == 3)
            {
                for (int i = 0; i < 50; i++)
                {
                    backTile[latelyIndex + 1, i] = 0;
                }
                GameObject.Find("Back").GetComponent<Image>().color = new Color(255, 255, 255, 1);

                int[] tile = new int[8];
                for (int i = 0; i < 8; i++)
                {
                    tile[i] = 2;
                }

                if (code[1] < height - 1)
                {
                    name = "Tile[" + (code[0]) + ";" + (code[1] + 1) + "]";
                    tile[0] = GameObject.Find(name).GetComponent<Tile>().condition;
                }
                if (code[1] < height - 1 && code[0] < width - 1)
                {
                    name = "Tile[" + (code[0] + 1) + ";" + (code[1] + 1) + "]";
                    tile[1] = GameObject.Find(name).GetComponent<Tile>().condition;
                }
                if (code[0] < width - 1)
                {
                    name = "Tile[" + (code[0] + 1) + ";" + (code[1]) + "]";
                    tile[2] = GameObject.Find(name).GetComponent<Tile>().condition;
                }
                if (code[1] > 0 && code[0] < width - 1)
                {
                    name = "Tile[" + (code[0] + 1) + ";" + (code[1] - 1) + "]";
                    tile[3] = GameObject.Find(name).GetComponent<Tile>().condition;
                }
                if (code[1] > 0)
                {
                    name = "Tile[" + (code[0]) + ";" + (code[1] - 1) + "]";
                    tile[4] = GameObject.Find(name).GetComponent<Tile>().condition;
                }
                if (code[1] > 0 && code[0] > 0)
                {
                    name = "Tile[" + (code[0] - 1) + ";" + (code[1] - 1) + "]";
                    tile[5] = GameObject.Find(name).GetComponent<Tile>().condition;
                }
                if (code[0] > 0)
                {
                    name = "Tile[" + (code[0] - 1) + ";" + (code[1]) + "]";
                    tile[6] = GameObject.Find(name).GetComponent<Tile>().condition;
                }
                if (code[0] > 0 && code[1] < height - 1)
                {
                    name = "Tile[" + (code[0] - 1) + ";" + (code[1] + 1) + "]";
                    tile[7] = GameObject.Find(name).GetComponent<Tile>().condition;
                }
                



                if (code[1] < height - 1)
                {
                    name = "Tile[" + (code[0]) + ";" + (code[1] + 1) + "]";
                    if (tile[7] == 2 && GameObject.Find(name).GetComponent<Tile>().condition == 1 || tile[7] != 2 && tile[7] != GameObject.Find(name).GetComponent<Tile>().condition)
                    {
                        ChangeColor(name);
                    }
                }
                if (code[1] < height - 1 && code[0] < width - 1)
                {
                    name = "Tile[" + (code[0] + 1) + ";" + (code[1] + 1) + "]";
                    if (tile[0] == 2 && GameObject.Find(name).GetComponent<Tile>().condition == 1 || tile[0] != 2 && tile[0] != GameObject.Find(name).GetComponent<Tile>().condition)
                    {
                        ChangeColor(name);
                    }
                }
                if (code[0] < width - 1)
                {
                    name = "Tile[" + (code[0] + 1) + ";" + (code[1]) + "]";
                    if (tile[1] == 2 && GameObject.Find(name).GetComponent<Tile>().condition == 1 || tile[1] != 2 && tile[1] != GameObject.Find(name).GetComponent<Tile>().condition)
                    {
                        ChangeColor(name);
                    }
                }
                if (code[1] > 0 && code[0] < width - 1)
                {
                    name = "Tile[" + (code[0] + 1) + ";" + (code[1] - 1) + "]";
                    if (tile[2] == 2 && GameObject.Find(name).GetComponent<Tile>().condition == 1 || tile[2] != 2 && tile[2] != GameObject.Find(name).GetComponent<Tile>().condition)
                    {
                        ChangeColor(name);
                    }
                }
                if (code[1] > 0)
                {
                    name = "Tile[" + (code[0]) + ";" + (code[1] - 1) + "]";
                    if (tile[3] == 2 && GameObject.Find(name).GetComponent<Tile>().condition == 1 || tile[3] != 2 && tile[3] != GameObject.Find(name).GetComponent<Tile>().condition)
                    {
                        ChangeColor(name);
                    }
                }
                if (code[1] > 0 && code[0] > 0)
                {
                    name = "Tile[" + (code[0] - 1) + ";" + (code[1] - 1) + "]";
                    if (tile[4] == 2 && GameObject.Find(name).GetComponent<Tile>().condition == 1 || tile[4] != 2 && tile[4] != GameObject.Find(name).GetComponent<Tile>().condition)
                    {
                        ChangeColor(name);
                    }
                }
                if (code[0] > 0)
                {
                    name = "Tile[" + (code[0] - 1) + ";" + (code[1]) + "]";
                    if (tile[5] == 2 && GameObject.Find(name).GetComponent<Tile>().condition == 1 || tile[5] != 2 && tile[5] != GameObject.Find(name).GetComponent<Tile>().condition)
                    {
                        ChangeColor(name);
                    }
                }
                if (code[0] > 0 && code[1] < height - 1)
                {
                    name = "Tile[" + (code[0] - 1) + ";" + (code[1] + 1) + "]";
                    if (tile[6] == 2 && GameObject.Find(name).GetComponent<Tile>().condition == 1 || tile[6] != 2 && tile[6] != GameObject.Find(name).GetComponent<Tile>().condition)
                    {
                        ChangeColor(name);
                    }
                }
            }
        }
    }

    void GameClear()
    {
        int color = 0;
        int count1 = 0, count2 = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                string name = "Tile[" + i + ";" + j + "]";
                if (GameObject.Find(name).GetComponent<Tile>().condition != 2)
                {
                    if (GameObject.Find(name).GetComponent<Tile>().condition == color)
                    {
                        count1++;
                    }
                    else
                    {
                        count2++;
                    }
                }

                if (j + 1 != height || height % 2 == 1)
                {
                    color = (color == 0) ? 1 : 0;
                }
            }
        }
        if (count1 == 0 || count2 == 0)
        {
            GameObject.Find("StageClear").GetComponent<StageClear>().isClear = true;
        }
    }

    void ChangeColor(string name)
    {
        if (GameObject.Find(name).GetComponent<Tile>().condition == 0)
        {
            StartCoroutine("BeBlack", GameObject.Find(name));
            GameObject.Find(name).GetComponent<Tile>().condition = 1;

            for(int i = 0; i < 50; i++)
            {
                if (backTile[latelyIndex + 1, i] == 0)
                {
                    backTile[latelyIndex + 1, i] = GameObject.Find(name).GetComponent<Tile>().code[0] + GameObject.Find(name).GetComponent<Tile>().code[1] * width + 1;
                    break;
                }
            }
        }
        else if (GameObject.Find(name).GetComponent<Tile>().condition == 1)
        {
            StartCoroutine("BeWhite", GameObject.Find(name));
            GameObject.Find(name).GetComponent<Tile>().condition = 0;

            for (int i = 0; i < 50; i++)
            {
                if (backTile[latelyIndex + 1, i] == 0)
                {
                    backTile[latelyIndex + 1, i] = GameObject.Find(name).GetComponent<Tile>().code[0] + GameObject.Find(name).GetComponent<Tile>().code[1] * width + 1;
                    break;
                }
            }
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
