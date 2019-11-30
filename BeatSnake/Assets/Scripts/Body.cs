using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public int x, y;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}