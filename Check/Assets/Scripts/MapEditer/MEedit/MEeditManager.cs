using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MEeditManager : MonoBehaviour {

    Image black;
    GameObject blackObj;
    GameObject newTile;
    GameObject tiles;
    float interval;
    public GameObject tile;
    public bool canTouch = false;
    public int height = 7;
    public int width = 5;

    public Sprite sprite_1Black;
    public Sprite sprite_1White;
    public Sprite sprite1Black;
    public Sprite sprite1White;
    public Sprite sprite2Black;
    public Sprite sprite2White;
    public Sprite sprite3Black;
    public Sprite sprite3White;
    public Sprite sprite4Black;
    public Sprite sprite4White;

    private void Awake()
    {
        black = GameObject.Find("BlackPanel").GetComponent<Image>();
        blackObj = GameObject.Find("BlackPanel");
        if (GameObject.Find("MEdata") != null)
        {
            height = GameObject.Find("MEdata").GetComponent<MEdata>().data_height;
            width = GameObject.Find("MEdata").GetComponent<MEdata>().data_width;
            Destroy(GameObject.Find("MEdata"));
        }
        tiles = GameObject.Find("Tiles");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("GuideText") == null && GameObject.Find("SaveSetting") == null)
        {
            StartCoroutine("BlackOn");
        }
    }

    private void Start()
    {
        GameObject.Find("BlackPanel2").SetActive(false);
        StartCoroutine("BlackOff");
        CreateTile();

        if (GameObject.Find("MEeditData") != null)
        {
            Destroy(GameObject.Find("MEeditData"));
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

                MEtile tileVar = newTile.GetComponent<MEtile>();
                SpriteRenderer renderer = newTile.GetComponent<SpriteRenderer>();
                tileVar.code[0] = i;
                tileVar.code[1] = j;

                if (GameObject.Find("MEeditData") != null)
                {
                    tileVar.condition = GameObject.Find("MEeditData").GetComponent<MEeditData>().condition[i + j * width];
                    tileVar.type = GameObject.Find("MEeditData").GetComponent<MEeditData>().type[i + j * width];

                    if (tileVar.type == -1)
                    {
                        if (tileVar.condition == 0)
                        {
                            renderer.sprite = sprite_1White;
                        }
                        else if (tileVar.condition == 1)
                        {
                            renderer.sprite = sprite_1Black;
                        }
                        else if (tileVar.condition == 2)
                        {
                            renderer.sprite = sprite_1White;
                            renderer.color = new Color(1, 1, 1, 0.12f);
                        }
                    }
                    else if (tileVar.type == 0)
                    {
                        if (tileVar.condition == 0)
                        {
                            renderer.sprite = sprite1White;
                        }
                        else if (tileVar.condition == 1)
                        {
                            renderer.sprite = sprite1Black;
                        }
                        else if (tileVar.condition == 2)
                        {
                            renderer.sprite = sprite1White;
                            renderer.color = new Color(1, 1, 1, 0.12f);
                        }
                    }
                    else if (tileVar.type == 1)
                    {
                        if (tileVar.condition == 0)
                        {
                            renderer.sprite = sprite2White;
                        }
                        else if (tileVar.condition == 1)
                        {
                            renderer.sprite = sprite2Black;
                        }
                        else if (tileVar.condition == 2)
                        {
                            renderer.sprite = sprite2White;
                            renderer.color = new Color(1, 1, 1, 0.12f);
                        }
                    }
                    else if (tileVar.type == 2)
                    {
                        if (tileVar.condition == 0)
                        {
                            renderer.sprite = sprite3White;
                        }
                        else if (tileVar.condition == 1)
                        {
                            renderer.sprite = sprite3Black;
                        }
                        else if (tileVar.condition == 2)
                        {
                            renderer.sprite = sprite3White;
                            renderer.color = new Color(1, 1, 1, 0.12f);
                        }
                    }
                    else if (tileVar.type == 3)
                    {
                        if (tileVar.condition == 0)
                        {
                            renderer.sprite = sprite4White;
                        }
                        else if (tileVar.condition == 1)
                        {
                            renderer.sprite = sprite4Black;
                        }
                        else if (tileVar.condition == 2)
                        {
                            renderer.sprite = sprite4White;
                            renderer.color = new Color(1, 1, 1, 0.12f);
                        }
                    }
                }
                else
                {
                    tileVar.condition = 0;
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
        canTouch = true;
        blackObj.SetActive(false);
    }

    IEnumerator BlackOn()
    {
        blackObj.SetActive(true);
        canTouch = false;
        for (float i = 0; i <= 110; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }
        SceneManager.LoadScene(62, LoadSceneMode.Single);
    }
}
