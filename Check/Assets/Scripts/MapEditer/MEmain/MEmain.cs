using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MEmain : MonoBehaviour {

    Image black1, black2;
    GameObject makeSetting;
    GameObject black;
    public GameObject mePlaySetting;
    bool canTouch = false;
    bool canTouch2 = true;

    private void Awake()
    {
        black1 = GameObject.Find("BlackPanel1").GetComponent<Image>();
        black2 = GameObject.Find("BlackPanel2").GetComponent<Image>();
        makeSetting = GameObject.Find("Canvas").transform.Find("MakeSetting").gameObject;
        black = GameObject.Find("BlackPanel2");
    }

    private void Start()
    {
        StartCoroutine("BlackOff");
    }

    private void Update()
    {
        Click();
        Menu();
    }

    void Menu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canTouch2)
        {
            StartCoroutine("BlackOn1");
        }
    }

    void Click()
    {
        if (Input.GetMouseButtonUp(0) && canTouch)
        {
            if (Input.mousePosition.x >= Input.mousePosition.y / Screen.height * Screen.width)
            {
                string[] split1 = GUIUtility.systemCopyBuffer.Split(new char[] { ';' });
                string[] split2 = split1[0].Split(new char[] { '*' });

                if (GUIUtility.systemCopyBuffer == null)
                {
                    GameObject.Find("Message").GetComponent<MEmessage>().text = "클립보드가 비어있습니다";
                    return;
                }
                else
                {

                    if (split1.Length != 2)
                    {
                        GameObject.Find("Message").GetComponent<MEmessage>().text = "잘못된 코드입니다";
                        return;
                    }
                    if (split2.Length != 2)
                    {
                        GameObject.Find("Message").GetComponent<MEmessage>().text = "잘못된 코드입니다";
                        return;
                    }
                    if (int.Parse(split2[0]) < 3 || int.Parse(split2[0]) > 15 || int.Parse(split2[1]) < 3 || int.Parse(split2[1]) > 15)
                    {
                        GameObject.Find("Message").GetComponent<MEmessage>().text = "잘못된 코드입니다";
                        return;
                    }
                    if (int.Parse(split2[0]) * int.Parse(split2[1]) != split1[1].Length)
                    {
                        GameObject.Find("Message").GetComponent<MEmessage>().text = "잘못된 코드입니다";
                        return;
                    }
                    for (int i = 0; i < split1[1].Length; i++)
                    {
                        if (split1[1][i] != '0' &&
                            split1[1][i] != '1' &&
                            split1[1][i] != '2' &&
                            split1[1][i] != '3' &&
                            split1[1][i] != '4' &&
                            split1[1][i] != '5' &&
                            split1[1][i] != '6' &&
                            split1[1][i] != '7' &&
                            split1[1][i] != '8' &&
                            split1[1][i] != '9' &&
                            split1[1][i] != 'a' &&
                            split1[1][i] != 'b' &&
                            split1[1][i] != 'c' &&
                            split1[1][i] != 'd' &&
                            split1[1][i] != 'e'
                            )
                        {
                            GameObject.Find("Message").GetComponent<MEmessage>().text = "잘못된 코드입니다";
                            return;
                        }
                    }

                }
                GameObject setting = Instantiate(mePlaySetting);
                StageSetting setting2 = setting.GetComponent<StageSetting>();
                setting.name = "StageSetting";

                setting2.width = (int.Parse(split2[0]));
                setting2.height = (int.Parse(split2[1]));

                for (int i = 0; i < split1[1].Length; i++)
                {
                    if (split1[1][i] == '0' || split1[1][i] == '3' || split1[1][i] == '6' || split1[1][i] == '9' || split1[1][i] == 'c')
                    {
                        setting2.condition[i] = 0;
                    }
                    else if (split1[1][i] == '1' || split1[1][i] == '4' || split1[1][i] == '7' || split1[1][i] == 'a' || split1[1][i] == 'd')
                    {
                        setting2.condition[i] = 1;
                    }
                    else if (split1[1][i] == '2' || split1[1][i] == '5' || split1[1][i] == '8' || split1[1][i] == 'b' || split1[1][i] == 'e')
                    {
                        setting2.condition[i] = 2;
                    }

                    if (split1[1][i] == '0' || split1[1][i] == '1' || split1[1][i] == '2')
                    {
                        setting2.type[i] = -1;
                    }
                    else if (split1[1][i] == '3' || split1[1][i] == '4' || split1[1][i] == '5')
                    {
                        setting2.type[i] = 0;
                    }
                    else if (split1[1][i] == '6' || split1[1][i] == '7' || split1[1][i] == '8')
                    {
                        setting2.type[i] = 1;
                    }
                    else if (split1[1][i] == '9' || split1[1][i] == 'a' || split1[1][i] == 'b')
                    {
                        setting2.type[i] = 2;
                    }
                    else if (split1[1][i] == 'c' || split1[1][i] == 'd' || split1[1][i] == 'e')
                    {
                        setting2.type[i] = 3;
                    }
                }
            

            StartCoroutine("BlackOn3");
                canTouch = false;
            }
            else
            {
                StartCoroutine("BlackOn");
                canTouch = false;
            }
        }
    }

    public void GoEdit()
    {
        StartCoroutine("BlackOn2");
    }

    IEnumerator BlackOn()
    {
        for (float i = 0; i <= 90; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black1.color = new Color(0, 0, 0, i / 100);
        }
        yield return new WaitForSeconds(0.35f);
        makeSetting.SetActive(true);
    }

    IEnumerator BlackOff()
    {
        yield return new WaitForSeconds(0.4f);
        for (float i = 100; i >= -10; i -= 3)
        {
            yield return new WaitForSeconds(0.007f);
            black2.color = new Color(0, 0, 0, i / 100);
        }
        canTouch = true;
        black.SetActive(false);
    }

    IEnumerator BlackOn1()
    {
        canTouch2 = false;
        black.SetActive(true);
        for (float i = 0; i <= 110; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black2.color = new Color(0, 0, 0, i / 100);
        }

        if (GameObject.Find("MakeSetting") != null)
        {
            SceneManager.LoadScene(62, LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
    }

    IEnumerator BlackOn2()
    {
        canTouch2 = false;
        black.SetActive(true);
        for (float i = 0; i <= 110; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black2.color = new Color(0, 0, 0, i / 100);
        }
        SceneManager.LoadScene(63, LoadSceneMode.Single);
    }

    IEnumerator BlackOn3()
    {
        canTouch2 = false;
        black.SetActive(true);
        for (float i = 0; i <= 110; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black2.color = new Color(0, 0, 0, i / 100);
        }
        SceneManager.LoadScene(64, LoadSceneMode.Single);
    }
}
