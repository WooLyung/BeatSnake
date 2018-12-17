using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopText : MonoBehaviour {

    public string text;
    public float time = 100f;
    Text textVar;

    private void Awake()
    {
        textVar = gameObject.GetComponent<Text>();
    }

    void Update () {
		if (text != null)
        {
            textVar.text = text;
            text = null;
            time = 400f;
            textVar.color = new Color(255, 255, 255, 1);
        }
        if (time > 0)
        {
            time -= Time.deltaTime * 150f;
            textVar.color = new Color(255, 255, 255, time / 100f);
            if (time < 0)
            {
                time = 0;
            }
        }
	}
}
