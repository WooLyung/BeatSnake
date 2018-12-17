using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoMapEditer : MonoBehaviour
{

    Image black;
    Vector2 mousePosition;

    public void Awake()
    {
        black = GameObject.Find("BlackPanel").GetComponent<Image>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            float length = Mathf.Abs(mousePosition.y - Input.mousePosition.y);
            if (length >= 0.3f * Screen.height)
            {
                if (mousePosition.y > Input.mousePosition.y)
                {
                    MapEditer();
                    return;
                }
            }
        }
    }

    public void MapEditer()
    {
        StartCoroutine("BlackOn");
    }

    IEnumerator BlackOn()
    {
        GameObject.Find("BlackPanel").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        for (float i = 0; i <= 110; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }

        SceneManager.LoadScene(62, LoadSceneMode.Single);
    }
}
