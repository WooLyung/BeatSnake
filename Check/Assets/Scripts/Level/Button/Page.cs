using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour {

    Image black;
    public Sprite blackT, white, gray, whiteH, blackH;
    public GameObject stage;
    LevelManager manager;
    public GameObject stages;

    Slider slider;

    Vector2 mousePosition;

    public void Update()
    {
        if (gameObject.name == "NextPage")
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                float length = Mathf.Abs(mousePosition.x - Input.mousePosition.x);
                if (length >= 0.3f * Screen.width && Input.mousePosition.y > Screen.height / 1280f * 170f)
                {
                    if (mousePosition.x - Input.mousePosition.x > 0)
                    {
                        Next();
                        return;
                    }
                    else
                    {
                        Previous();
                        return;
                    }
                }
            }
        }
    }

    public void ChangeChapter()
    {
        manager = GameObject.Find("Manager").GetComponent<LevelManager>();
        black = GameObject.Find("BlackPanel").GetComponent<Image>();
        slider = GameObject.Find("MapSlider").GetComponent<Slider>();
        
        if (slider.value ==  0)
        {
            manager.chapter = "Black";
        }
        else if (slider.value == 1)
        {
            manager.chapter = "Green";
        }
        else if (slider.value == 2)
        {
            manager.chapter = "Blue";
        }
        else if (slider.value == 3)
        {
            manager.chapter = "Yellow";
        }
        else if (slider.value == 4)
        {
            manager.chapter = "Red";
        }
        else if (slider.value == 5)
        {
            manager.chapter = "Purple";
        }
        else if (slider.value == 6)
        {
            manager.chapter = "Orange";
        }

        StartCoroutine("Black");
        StartCoroutine("NewTile");
    }

    public void Previous()
    {
        manager = GameObject.Find("Manager").GetComponent<LevelManager>();
        black = GameObject.Find("BlackPanel").GetComponent<Image>();

        if (manager.chapter == "Black")
        {
            GameObject.Find("TopText").GetComponent<TopText>().text = "이전 챕터로 갈 수 없습니다.";
            return;
        }
        else if (manager.chapter == "Green")
        {
            manager.chapter = "Black";
        }
        else if (manager.chapter == "Blue")
        {
            manager.chapter = "Green";
        }
        else if (manager.chapter == "Yellow")
        {
            manager.chapter = "Blue";
        }
        else if (manager.chapter == "Red")
        {
            manager.chapter = "Yellow";
        }
        else if (manager.chapter == "Purple")
        {
            manager.chapter = "Red";
        }
        else if (manager.chapter == "Orange")
        {
            manager.chapter = "Purple";
        }
        StartCoroutine("Black");
        StartCoroutine("NewTile");
    }

    public void Next()
    {
        manager = GameObject.Find("Manager").GetComponent<LevelManager>();
        black = GameObject.Find("BlackPanel").GetComponent<Image>();

        if (manager.chapter == "Purple")
        {
            GameObject.Find("TopText").GetComponent<TopText>().text = "다음 챕터로 갈 수 없습니다.";
            return;
        }
        else if (manager.chapter == "Black" && PlayerPrefs.GetInt("Clear-" + manager.chapter + 20) == 1)
        {
            manager.chapter = "Green";
        }
        else if (manager.chapter == "Green" && PlayerPrefs.GetInt("Clear-" + manager.chapter + 20) == 1)
        {
            manager.chapter = "Blue";
        }
        else if (manager.chapter == "Blue" && PlayerPrefs.GetInt("Clear-" + manager.chapter + 20) == 1)
        {
            manager.chapter = "Yellow";
        }
        else if (manager.chapter == "Yellow" && PlayerPrefs.GetInt("Clear-" + manager.chapter + 20) == 1)
        {
            manager.chapter = "Red";
        }
        else if (manager.chapter == "Red" && PlayerPrefs.GetInt("Clear-" + manager.chapter + 20) == 1)
        {
            manager.chapter = "Purple";
        }
        else
        {
            GameObject.Find("TopText").GetComponent<TopText>().text = "챕터의 모든 레벨을 완료해야 합니다.";
            return;
        }
        StartCoroutine("Black");
        StartCoroutine("NewTile");
    }

    IEnumerator Black()
    {
        manager.canTouch = false;
        GameObject.Find("BlackPanel").GetComponent<RectTransform>().localScale = new Vector2(1, 1);

        for (float i = 0; i <= 110; i += 12)
        {
            yield return new WaitForSeconds(0.01f);
            black.color = new Color(0, 0, 0, i / 100);
        }

        GameObject.Find("BlackPanel").GetComponent<RectTransform>().localScale = new Vector2(1, 1);

        if (manager.chapter == "Black")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(11f / 225, 11f / 225, 11f / 225);
        }
        else if (manager.chapter == "Green")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(0, 40f / 255, 0);
        }
        else if (manager.chapter == "Blue")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(0, 0, 40f / 255);
        }
        else if (manager.chapter == "Yellow")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(40f / 255, 40f / 255, 0);
        }
        else if (manager.chapter == "Red")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(40f / 255, 0, 0);
        }
        else if (manager.chapter == "Purple")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(40f / 255, 0, 40f / 255);
        }
        else if (manager.chapter == "Orange")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(40f / 255, 20f / 255, 0);
        }
        for (float i = 100; i >= -10; i -= 12)
        {
            yield return new WaitForSeconds(0.01f);
            black.color = new Color(0, 0, 0, i / 100);
        }

        yield return new WaitForSeconds(0.01f);
        manager.canTouch = true;
        GameObject.Find("BlackPanel").GetComponent<RectTransform>().localScale = new Vector2(0, 0);
    }

    IEnumerator NewTile()
    {
        yield return new WaitForSeconds(0.16f);

        GameObject.Find("Chapter").GetComponent<Text>().text = manager.chapter;
        Destroy(GameObject.Find("Stages"));
        GameObject Stages = Instantiate(stages);
        Stages.transform.SetParent(GameObject.Find("STA").transform);
        Stages.name = "Stages";

        yield return new WaitForSeconds(0.01f);

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject newStage = Instantiate(stage);
                newStage.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 550f, Screen.width / 550f);
                newStage.GetComponent<RectTransform>().position = new Vector2(Screen.width / 2 + Screen.width * (i - 1.5f) * 0.19f, Screen.height / 2 + Screen.height * (j - 1.5f) * -0.115f);
                newStage.GetComponent<StageButton>().stage = j * 4 + i + 1;
                newStage.transform.SetParent(GameObject.Find("Stages").transform);
                newStage.name = "stage" + (j * 5 + i + 1);
                newStage.GetComponentInChildren<Text>().text = "" + (j * 4 + i + 1);

                if (PlayerPrefs.GetInt("Clear-" + manager.chapter + (j * 4 + i + 1)) == 1)
                {
                    if (i % 2 == j % 2)
                    {
                        if (PlayerPrefs.GetInt("HardClear-" + manager.chapter + (j * 4 + i + 1)) == 1)
                            newStage.GetComponent<Image>().sprite = whiteH;
                        else
                            newStage.GetComponent<Image>().sprite = white;
                        newStage.GetComponentInChildren<Text>().color = new Color(0, 0, 0);
                    }
                    else
                    {
                        if (PlayerPrefs.GetInt("HardClear-" + manager.chapter + (j * 4 + i + 1)) == 1)
                            newStage.GetComponent<Image>().sprite = blackH;
                        else
                            newStage.GetComponent<Image>().sprite = blackT;
                        newStage.GetComponentInChildren<Text>().color = new Color(1, 1, 1);
                    }
                }
                else if (j * 5 + i + 1 == 1 || PlayerPrefs.GetInt("Clear-" + manager.chapter + (j * 4 + i)) == 1)
                {
                    newStage.GetComponent<Image>().sprite = gray;
                    newStage.GetComponentInChildren<Text>().color = new Color(1, 1, 1);
                }
                else
                {
                    newStage.GetComponent<Image>().color = new Color(1, 1, 1, 0.25f);
                    newStage.GetComponentInChildren<Text>().color = new Color(1, 1, 1, 0.6f);
                }
            }
        }
    }
}
