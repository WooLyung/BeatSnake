using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    Text text;
    Image black;

    bool canTouch = false;

    private void Awake()
    {
        text = GameObject.Find("Text").GetComponent<Text>();
        black = GameObject.Find("BlackPanel").GetComponent<Image>();
    }

    private void Start()
    {
        StartCoroutine("BlackOff");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canTouch)
        {
            canTouch = false;
            StartCoroutine("BlackOn");
        }
    }

    IEnumerator Text()
    {
        for (float i = 0; i <= 110; i += 5)
        {
            yield return new WaitForSeconds(0.007f);
            text.color = new Color(255, 255, 255, i / 100);
        }
        yield return new WaitForSeconds(1.35f);
        for (float i = 100; i >= -10; i -= 5)
        {
            yield return new WaitForSeconds(0.007f);
            text.color = new Color(255, 255, 255, i / 100);
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("Text");
    }

    IEnumerator BlackOff()
    {
        yield return new WaitForSeconds(0.4f);
        for (float i = 100; i >= -10; i -= 3)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }
        yield return new WaitForSeconds(0.6f);
        StartCoroutine("Text");
        canTouch = true;
    }

    IEnumerator BlackOn()
    {
        for (float i = 0; i <= 110; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
