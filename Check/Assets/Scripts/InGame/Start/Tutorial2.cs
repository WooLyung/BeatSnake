using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial2 : MonoBehaviour {

    int width;
    int height;
    int[] condition;
    int[] type;
    int stage, nowIndex;
    public int Tcondition;
    string chapter;

    Image blackPanel;
    GameObject newTile;
    GameObject tiles;
    GameObject newText;

    Text tutorialText;

    GameObject image1;

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

        image1 = GameObject.Find("Image1");

        tutorialText = GameObject.Find("TutoMessage").GetComponent<Text>();

        Tcondition = 0;
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Option2") == 1)
        {
            new GameObject("HardMode");
        }

        GameObject.Find("Level").GetComponent<Text>().text = chapter + " " + stage;
        GameObject.Find("ClearText").GetComponent<Text>().text = "튜토리얼 완료!";
        GameObject.Find("Canvas").transform.Find("Boast").Find("Text").GetComponent<Text>().text = "페이스북에 글 올리기       ";

        StartCoroutine("BlackOff");
    }

    private void Update()
    {
        if (Tcondition == 0 || (Input.GetMouseButton(0) && (Tcondition == 2 || Tcondition == 4 || Tcondition == 6 || Tcondition == 8) && canTouch == false))
        {
            StartCoroutine("Tutorial");
        }
    }

    IEnumerator Tutorial()
    {
        if (Tcondition == 0)
        {
            {
                Tcondition = 1;
                yield return new WaitForSeconds(1.2f);
                for (float i = 0; i <= 110; i += 8)
                {
                    yield return new WaitForSeconds(0.01f);
                    tutorialText.color = new Color(1, 1, 1, i / 100f);
                }

                Tcondition = 2;
            }
        }
        else if (Tcondition == 2)
        {
            {
                Tcondition = 3;

                for (float i = 100; i >= -10; i -= 8)
                {
                    yield return new WaitForSeconds(0.01f);
                    tutorialText.color = new Color(1, 1, 1, i / 100f);
                }
                tutorialText.text = "그 외 다양한 타일들이 존재하며,\n챕터마다 한 종류씩 등장합니다.\n\n\n\n";
                for (float i = 0; i <= 110; i += 8)
                {
                    yield return new WaitForSeconds(0.01f);
                    tutorialText.color = new Color(1, 1, 1, i / 100f);
                    image1.transform.Find("Image1-1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, i / 100f);
                    image1.transform.Find("Image1-2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, i / 100f);
                    image1.transform.Find("Image1-3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, i / 100f);
                }

                Tcondition = 4;
            }
        }
        else if (Tcondition == 4)
        {
            {
                Tcondition = 5;

                for (float i = 100; i >= -10; i -= 8)
                {
                    yield return new WaitForSeconds(0.01f);
                    tutorialText.color = new Color(1, 1, 1, i / 100f);
                    image1.transform.Find("Image1-1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, i / 100f);
                    image1.transform.Find("Image1-2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, i / 100f);
                    image1.transform.Find("Image1-3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, i / 100f);
                }
                tutorialText.text = "상단의 UI는 각각\n되돌리기/다시하기/메뉴 입니다.";
                for (float i = 0; i <= 110; i += 8)
                {
                    yield return new WaitForSeconds(0.01f);
                    tutorialText.color = new Color(1, 1, 1, i / 100f);
                }

                Tcondition = 6;
            }
        }
        else if (Tcondition == 6)
        {
            {
                Tcondition = 7;

                for (float i = 100; i >= -10; i -= 8)
                {
                    yield return new WaitForSeconds(0.01f);
                    tutorialText.color = new Color(1, 1, 1, i / 100f);
                }
                tutorialText.text = "튜토리얼은 여기까지이며, 짤막한\n가이드들은 하단에 표시됩니다.";
                for (float i = 0; i <= 110; i += 8)
                {
                    yield return new WaitForSeconds(0.01f);
                    tutorialText.color = new Color(1, 1, 1, i / 100f);
                }

                Tcondition = 8;
            }
        }
        else if (Tcondition == 8)
        {
            Tcondition = 9;
            for (float i = 100; i >= -10; i -= 8)
            {
                yield return new WaitForSeconds(0.01f);
                tutorialText.color = new Color(1, 1, 1, i / 100f);
            }
            CreateTile();
        }
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
        yield return new WaitForSeconds(0.35f);
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
