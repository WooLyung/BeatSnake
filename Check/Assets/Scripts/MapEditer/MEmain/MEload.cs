using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MEload : MonoBehaviour {

    public GameObject data;
    public GameObject data2;

    public void Load()
    {
        if (GUIUtility.systemCopyBuffer == null)
        {
            GameObject.Find("Message").GetComponent<MEmessage>().text = "클립보드가 비어있습니다";
            return;
        }
        else
        {
            string[] split1 = GUIUtility.systemCopyBuffer.Split(new char[] { ';' });
            string[] split2 = split1[0].Split(new char[] { '*' });

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
            GameObject newObject = Instantiate(data);
            newObject.GetComponent<MEdata>().data_height = int.Parse(split2[1]);
            newObject.GetComponent<MEdata>().data_width = int.Parse(split2[0]);
            newObject.name = "MEdata";

            GameObject newObject2 = Instantiate(data2);
            newObject2.name = "MEeditData";
            MEeditData setting = newObject2.GetComponent<MEeditData>();

            for (int i = 0; i < split1[1].Length; i++)
            {
                if (split1[1][i] == '0' || split1[1][i] == '3' || split1[1][i] == '6' || split1[1][i] == '9' || split1[1][i] == 'c')
                {
                    setting.condition[i] = 0;
                }
                else if (split1[1][i] == '1' || split1[1][i] == '4' || split1[1][i] == '7' || split1[1][i] == 'a' || split1[1][i] == 'd')
                {
                    setting.condition[i] = 1;
                }
                else if (split1[1][i] == '2' || split1[1][i] == '5' || split1[1][i] == '8' || split1[1][i] == 'b' || split1[1][i] == 'e')
                {
                    setting.condition[i] = 2;
                }

                if (split1[1][i] == '0' || split1[1][i] == '1' || split1[1][i] == '2')
                {
                    setting.type[i] = -1;
                }
                else if (split1[1][i] == '3' || split1[1][i] == '4' || split1[1][i] == '5')
                {
                    setting.type[i] = 0;
                }
                else if (split1[1][i] == '6' || split1[1][i] == '7' || split1[1][i] == '8')
                {
                    setting.type[i] = 1;
                }
                else if (split1[1][i] == '9' || split1[1][i] == 'a' || split1[1][i] == 'b')
                {
                    setting.type[i] = 2;
                }
                else if (split1[1][i] == 'c' || split1[1][i] == 'd' || split1[1][i] == 'e')
                {
                    setting.type[i] = 3;
                }
            }
            GameObject.Find("Manager").GetComponent<MEmain>().GoEdit();
        }
    }
}