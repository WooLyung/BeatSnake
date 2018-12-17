using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEdata : MonoBehaviour {

    public int data_width = 3;
    public int data_height = 3;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
