using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEplayManager : MonoBehaviour
{

    void Start()
    {
        StartCoroutine("Remove");
    }

    IEnumerator Remove()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(GameObject.Find("StageSetting"));
    }
}
