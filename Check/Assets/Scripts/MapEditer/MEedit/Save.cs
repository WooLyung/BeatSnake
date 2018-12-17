using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour {

    GameObject saveSetting;
    GameObject BlackPanel;
    GameObject BlackPanel2;

    public GameObject mePlaySetting;

    MEeditManager manager;

    Image black;
    Image black2;

    string mapCode;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("SaveSetting") != null)
        {
            manager.canTouch = true;
            black2.color = new Color(1, 1, 1, 0);
            BlackPanel2.SetActive(false);
            saveSetting.SetActive(false);
        }
    }

    public void Facebook()
    {
        GameObject.Find("Message").GetComponent<MEmessage>().text = "페이스북으로 연결합니다";
        manager.canTouch = true;
        black2.color = new Color(1, 1, 1, 0);
        BlackPanel2.SetActive(false);
        saveSetting.SetActive(false);
    }

    public void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<MEeditManager>();
        saveSetting = GameObject.Find("Canvas").transform.Find("SaveSetting").gameObject;
        BlackPanel = GameObject.Find("BlackPanel");
        black = BlackPanel.GetComponent<Image>();
        BlackPanel2 = GameObject.Find("BlackPanel2");
        black2 = BlackPanel2.GetComponent<Image>();
    }

    public void Clipboard()
    {
        GameObject.Find("Message").GetComponent<MEmessage>().text = "클립보드에 맵 코드를 복사하였습니다";
        manager.canTouch = true;
        black2.color = new Color(1, 1, 1, 0);
        BlackPanel2.SetActive(false);
        saveSetting.SetActive(false);

        GUIUtility.systemCopyBuffer = mapCode;
    }

    public void CopyPlay()
    {
        GameObject.Find("Message").GetComponent<MEmessage>().text = "클립보드로 복사했으며, 즉시 플레이합니다";

        GUIUtility.systemCopyBuffer = mapCode;

        string[] split1 = GUIUtility.systemCopyBuffer.Split(new char[] { ';' });
        string[] split2 = split1[0].Split(new char[] { '*' });
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

        StartCoroutine("GameStart");
    }


    public void MapSave()
    {
        mapCode = manager.width + "*" + manager.height + ";";
        for (int j = 0; j < manager.height; j++)
        {
            for (int i = 0; i < manager.width; i++)
            {
                int condition = GameObject.Find("Tile[" + i + ";" + j + "]").GetComponent<MEtile>().condition;
                int type = GameObject.Find("Tile[" + i + ";" + j + "]").GetComponent<MEtile>().type;
                if (type == -1)
                {
                    if (condition == 0)
                        mapCode += "0";
                    else if (condition == 1)
                        mapCode += "1";
                    else if (condition == 2)
                        mapCode += "2";
                }
                else if (type == 0)
                {
                    if (condition == 0)
                        mapCode += "3";
                    else if (condition == 1)
                        mapCode += "4";
                    else if (condition == 2)
                        mapCode += "5";
                }
                else if (type == 1)
                {
                    if (condition == 0)
                        mapCode += "6";
                    else if (condition == 1)
                        mapCode += "7";
                    else if (condition == 2)
                        mapCode += "8";
                }
                else if (type == 2)
                {
                    if (condition == 0)
                        mapCode += "9";
                    else if (condition == 1)
                        mapCode += "a";
                    else if (condition == 2)
                        mapCode += "b";
                }
                else if (type == 3)
                {
                    if (condition == 0)
                        mapCode += "c";
                    else if (condition == 1)
                        mapCode += "d";
                    else if (condition == 2)
                        mapCode += "e";
                }
            }
        }
        BlackPanel2.SetActive(true);
        StartCoroutine("Black2On");
    }

    IEnumerator Black2On()
    {
        manager.canTouch = false;
        for (float i = 0; i <= 90; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black2.color = new Color(0, 0, 0, i / 100);
        }
        yield return new WaitForSeconds(0.3f);
        saveSetting.SetActive(true);
    }

    IEnumerator GameStart()
    {
        manager.canTouch = false;
        BlackPanel.SetActive(true);
        for (float i = 0; i <= 110; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }
        SceneManager.LoadScene(64, LoadSceneMode.Single);
    }
}
