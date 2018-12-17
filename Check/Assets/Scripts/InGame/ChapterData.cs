using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterData : MonoBehaviour {

    public string chapter = "Black";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
