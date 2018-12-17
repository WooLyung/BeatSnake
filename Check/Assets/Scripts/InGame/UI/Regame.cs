using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Regame : MonoBehaviour {

    Image black;
    int stage;

    public GameObject mePlaySetting;

    private void Awake()
    {
        black = GameObject.Find("BlackPanel").GetComponent<Image>();
        stage = GameObject.Find("StageSetting").GetComponent<StageSetting>().nowIndex;
    }

    public void Re()
    {
        if (GameObject.Find("StageClear").GetComponent<StageClear>().clearing == 0)
        {
            StartCoroutine("BlackOn");
        }
    }

    IEnumerator BlackOn()
    {
        if (GameObject.Find("MePlayManager") != null)
        {
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
        }

        GameObject.Find("StageClear").GetComponent<StageClear>().clearing = 3;
        GameObject.Find("BlackPanel").GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        for (float i = 0; i <= 110; i += 6)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }
        SceneManager.LoadScene(stage, LoadSceneMode.Single);
    }
}
