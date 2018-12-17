using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help : MonoBehaviour
{
    GameObject helps;
    GameObject BlackPanel;
    Image black;
    LevelManager manager;

    public void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<LevelManager>();
        helps = GameObject.Find("Canvas").transform.Find("Helps").gameObject;
        BlackPanel = GameObject.Find("Canvas").transform.Find("BlackPanel2").gameObject;
        black = BlackPanel.GetComponent<Image>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("Helps") != null)
        {
            StartCoroutine("BlackOff");
        }
    }

    public void OpenHelp()
    {
        if (manager.canTouch)
        {
            StartCoroutine("BlackOn");
        }
    }

    const string FACEBOOK_APP_ID = "641405499585769";
    const string FACEBOOK_URL = "http://www.facebook.com/dialog/feed";

    public static void ShareToFacebook(
    string linkParameter, string pictureParameter, string redirectParameter
    )
    {
        Application.OpenURL(FACEBOOK_URL + "?app_id=" + FACEBOOK_APP_ID +
        "&link=" + WWW.EscapeURL(linkParameter) +
        "&picture=" + WWW.EscapeURL(pictureParameter) +
        "&redirect_uri=" + WWW.EscapeURL(redirectParameter));
    }

    public void Promotion()
    {
        ShareToFacebook(
        "http://play.google.com/store/apps/details?id=com.WooLyung.Check",            // linkParameter
        "https://lh3.googleusercontent.com/-heaNDpxttXs/W17yZqxBk8I/AAAAAAAAAEc/kXvp1qHj0MMQWElCcwBLIoy_h6oZpOdwACL0BGAs/w663-d-h324-n-rw/37897186_1976230739344056_1042676802289401856_n.jpg", //pictureParameter
        "http://www.facebook.com"       // redirectParamter
        );
    }

    public void Review()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.WooLyung.Check");
    }

    IEnumerator BlackOn()
    {
        manager.canTouch = false;
        BlackPanel.SetActive(true);
        for (float i = 0; i <= 90; i += 3)
        {
            yield return new WaitForSeconds(0.007f);
            black.color = new Color(0, 0, 0, i / 100);
        }
        yield return new WaitForSeconds(0.3f);
        helps.SetActive(true);
    }

    IEnumerator BlackOff()
    {
        yield return new WaitForSeconds(0.007f);
        black.color = new Color(0, 0, 0, 0);
        BlackPanel.SetActive(false);
        helps.SetActive(false);
        manager.canTouch = true;
    }

    private void Start()
    {
        gameObject.GetComponent<RectTransform>().localScale = new Vector2(Screen.width / 720f, Screen.width / 720f);
        gameObject.GetComponent<RectTransform>().position = new Vector2(Screen.width + Screen.width / 720f * -90f, Screen.height / 1280f * 30f);
    }
}
