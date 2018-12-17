using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boast : MonoBehaviour {

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

	public void BoastFacebook()
    {
        ShareToFacebook(
        "http://play.google.com/store/apps/details?id=com.WooLyung.Check",            // linkParameter
        "https://lh3.googleusercontent.com/-heaNDpxttXs/W17yZqxBk8I/AAAAAAAAAEc/kXvp1qHj0MMQWElCcwBLIoy_h6oZpOdwACL0BGAs/w663-d-h324-n-rw/37897186_1976230739344056_1042676802289401856_n.jpg", //pictureParameter
        "http://www.facebook.com"       // redirectParamter
        );
    }
}
