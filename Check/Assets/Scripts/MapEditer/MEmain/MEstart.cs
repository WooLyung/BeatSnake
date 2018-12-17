using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MEstart : MonoBehaviour {

    public GameObject data;

	public void EditStart()
    {
        if (GameObject.Find("InputWidth").transform.Find("Text").GetComponent<Text>().text == "" || GameObject.Find("InputHeight").transform.Find("Text").GetComponent<Text>().text == "")
        {
            GameObject.Find("Message").GetComponent<MEmessage>().text = "맵 크기를 입력하세요";
            return;
        }
        int width = int.Parse(GameObject.Find("InputWidth").transform.Find("Text").GetComponent<Text>().text);
        int height = int.Parse(GameObject.Find("InputHeight").transform.Find("Text").GetComponent<Text>().text);
        if (width < 3 || height < 3)
        {
            GameObject.Find("Message").GetComponent<MEmessage>().text = "맵은 3타일 이상이어야 합니다";
        }
        else if (width > 15 || height > 15)
        {
            GameObject.Find("Message").GetComponent<MEmessage>().text = "맵은 15타일 이하이어야 합니다";
        }
        else
        {
            GameObject newObject = Instantiate(data);
            newObject.GetComponent<MEdata>().data_height = height;
            newObject.GetComponent<MEdata>().data_width = width;
            newObject.name = "MEdata";
            GameObject.Find("Manager").GetComponent<MEmain>().GoEdit();
        }
    }
}
