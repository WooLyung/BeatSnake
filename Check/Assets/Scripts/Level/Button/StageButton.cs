using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    public int stage = 0;
    string chapter;
    Image black;
    int index;

    public void Awake()
    {
        black = GameObject.Find("BlackPanel").GetComponent<Image>();
        chapter = GameObject.Find("Manager").GetComponent<LevelManager>().chapter;
    }

    public void Touch()
    {
        if (GameObject.Find("Manager").GetComponent<LevelManager>().movePower == 0)
        {
            if (PlayerPrefs.GetInt("Clear-" + chapter + stage) == 1 || stage == 1 || PlayerPrefs.GetInt("Clear-" + chapter + (stage - 1)) == 1)
            {
                StartCoroutine("BlackOn");
                GameObject.Find("Manager").GetComponent<LevelManager>().canTouch = false;
            }
            else
            {
                Debug.Log(1);
                GameObject.Find("TopText").GetComponent<TopText>().text = "이전 레벨들을 모두 완료해야 합니다.";
            }
        }
    }

    IEnumerator BlackOn()
    {
        GameObject.Find("BlackPanel").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        for (float i = 0; i <= 110; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }

        if (chapter == "Black")
        {
            index = 1;
        }
        if (chapter == "Green")
        {
            index = 21;
        }
        if (chapter == "Blue")
        {
            index = 41;
        }
        if (chapter == "Yellow")
        {
            index = 64;
        }
        if (chapter == "Red")
        {
            index = 84;
        }
        if (chapter == "Purple")
        {
            index = 104;
        }
        if (chapter == "Orange")
        {
            index = 124;
        }
        SceneManager.LoadScene(stage + index, LoadSceneMode.Single);
    }
}
