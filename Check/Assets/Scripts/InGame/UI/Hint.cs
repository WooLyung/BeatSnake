using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour {

    public int[] tiles = new int[1];
    public GameObject hint;
    GameObject newObject;
    public Sprite white;
    int width;
    int height;
    bool canHint;

    private void Awake()
    {
        width = GameObject.Find("StageSetting").GetComponent<StageSetting>().width;
        height = GameObject.Find("StageSetting").GetComponent<StageSetting>().height;
    }

    public void Hints()
    {
        bool can = false;

        if (GameObject.Find("Tutorial") != null && GameObject.Find("StartManager").GetComponent<Tutorial1>() != null)
        {
            if (GameObject.Find("StartManager").GetComponent<Tutorial1>().Tcondition == 7)
            {
                can = true;
            }
        }
        else if (GameObject.Find("Tutorial") != null)
        {
            if (GameObject.Find("StartManager").GetComponent<Tutorial2>().Tcondition == 9)
            {
                can = true;
            }
        }
        else if (GameObject.Find("StartManager") != null)
        {
            can = true;
        }

        if (can)
        {
            float interval;
            if (height * 5 < width * 7)
            {
                interval = 5.0f / width;
            }
            else
            {
                interval = 7.0f / height;
            }
            if (GameObject.Find("StageClear").GetComponent<StageClear>().clearing == 0)
            {
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (tiles[i * height + j] == 1)
                        {
                            newObject = Instantiate(hint);
                            float size = interval / 5;
                            newObject.transform.localScale = new Vector2(size, size);
                            newObject.name = "hint";

                            if (height * 5 < width * 7)
                            {
                                float wid = interval * i + interval / 2.5f - 2.5f + 0.5f / width;
                                float hei = interval * j + interval / 2.5f - height * 2.5f / width + 0.5f / height;
                                newObject.transform.position = new Vector3(wid, hei, -2);
                            }
                            else
                            {
                                float wid = interval * i + interval / 2.5f - width * 3.5f / height + 0.5f / width;
                                float hei = interval * j + interval / 2.5f - 3.5f + 0.5f / height;
                                newObject.transform.position = new Vector3(wid, hei, -2);
                            }

                            if (GameObject.Find("Tile[" + i + ";" + j + "]").GetComponent<Tile>().condition == 1)
                            {
                                newObject.GetComponent<SpriteRenderer>().sprite = white;
                            }
                        }
                    }
                }
            }
        }
    }

    private void Start()
    {
        if (gameObject.name == "hint")
        {
            StartCoroutine("RemoveHint");
        }
    }

    IEnumerator RemoveHint()
    {
        yield return new WaitForSeconds(1f);
        for (float i = 100; i > - 10; i -= 3)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, i / 100);
            yield return new WaitForSeconds(0.007f);
        }
        Destroy(gameObject);
    }
}
