using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEplaySetting : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
