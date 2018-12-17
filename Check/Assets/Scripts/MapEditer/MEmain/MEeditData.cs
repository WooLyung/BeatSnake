using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEeditData : MonoBehaviour {

    public int[] type = new int[225];
    public int[] condition = new int[225];

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
