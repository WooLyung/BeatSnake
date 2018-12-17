using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    Image black;

    public bool canTouch = false;
    public GameObject stage;
    RectTransform stages;

    public Sprite blackT;
    public Sprite white;
    public Sprite gray;
    public Sprite whiteH;
    public Sprite blackH;
    public string chapter = "Black";

    Slider slider;
    Vector2 mousePosition;
    float moveSpeed = 0f;
    public float movePower = 0f;

    private void Awake()
    {
        black = GameObject.Find("BlackPanel").GetComponent<Image>();
        stages = GameObject.Find("Stages").GetComponent<RectTransform>();
        slider = GameObject.Find("MapSlider").GetComponent<Slider>();

        chapter = "Black";
        if (PlayerPrefs.GetInt("Clear-Black20") == 1)
        {
            chapter = "Green";
        }
        if (PlayerPrefs.GetInt("Clear-Green20") == 1)
        {
            chapter = "Blue";
        }
        if (PlayerPrefs.GetInt("Clear-Blue20") == 1)
        {
            chapter = "Yellow";
        }
        if (PlayerPrefs.GetInt("Clear-Yellow20") == 1)
        {
            chapter = "Red";
        }
        if (PlayerPrefs.GetInt("Clear-Red20") == 1)
        {
            chapter = "Purple";
        }

        if (GameObject.Find("ChapterData") != null)
        {
            chapter = GameObject.Find("ChapterData").GetComponent<ChapterData>().chapter;
            Destroy(GameObject.Find("ChapterData"));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("BlackPanel2") == null)
        {
            Application.Quit();
        }

        if (Input.GetKeyDown("a"))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    private void Start()
    {
        GameObject.Find("Chapter").GetComponent<Text>().text = chapter;
        if (chapter == "Green")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(0, 40f / 255, 0);
            slider.value = 1;
        }
        else if (chapter == "Blue")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(0, 0, 40f / 255);
            slider.value = 2;
        }
        else if (chapter == "Yellow")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(40f / 255, 40f / 255, 0);
            slider.value = 3;
        }
        else if (chapter == "Red")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(40f / 255, 0, 0);
            slider.value = 4;
        }
        else if (chapter == "Purple")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(40f / 255, 0, 40f / 255);
            slider.value = 5;
        }
        else if (chapter == "Orange")
        {
            GameObject.Find("Main Camera").GetComponent<Camera>().backgroundColor = new Color(40f / 255, 20f / 255, 0);
            slider.value = 6;
        }
        else
        {
            slider.value = 0;
        }

        StartCoroutine("BlackOff");
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

                if (PlayerPrefs.GetInt("Clear-" + chapter + (j * 4 + i + 1)) == 1)
                {
                    if (i % 2 == j % 2)
                    {
                        if (PlayerPrefs.GetInt("HardClear-" + chapter + (j * 4 + i + 1)) == 1)
                            newStage.GetComponent<Image>().sprite = whiteH;
                        else
                            newStage.GetComponent<Image>().sprite = white;
                        newStage.GetComponentInChildren<Text>().color = new Color(0, 0, 0);
                    }
                    else
                    {
                        if (PlayerPrefs.GetInt("HardClear-" + chapter + (j * 4 + i + 1)) == 1)
                            newStage.GetComponent<Image>().sprite = blackH;
                        else
                            newStage.GetComponent<Image>().sprite = blackT;
                        newStage.GetComponentInChildren<Text>().color = new Color(1, 1, 1);
                    }
                }
                else if (j * 5 + i + 1 == 1 || PlayerPrefs.GetInt("Clear-" + chapter + (j * 4 + i)) == 1)
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

    IEnumerator BlackOff()
    {
        yield return new WaitForSeconds(0.4f);
        for (float i = 100; i >= -10; i -= 3)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }
        yield return new WaitForSeconds(0.6f);
        canTouch = true;
        GameObject.Find("BlackPanel").GetComponent<RectTransform>().localScale = new Vector2(0, 0);
    }
}
