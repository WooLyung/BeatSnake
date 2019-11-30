using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public int x, y;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}