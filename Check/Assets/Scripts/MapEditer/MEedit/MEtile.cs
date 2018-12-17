using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEtile : MonoBehaviour {

    public int condition = 0;
    public int type = 0;
    public int[] code = new int[2];
    bool onMouse = false;
    float stayTime = -1;
    SpriteRenderer spriteRenderer;
    MEeditManager manager;

    public Sprite sprite_1Black;
    public Sprite sprite_1White;
    public Sprite sprite1Black;
    public Sprite sprite1White;
    public Sprite sprite2Black;
    public Sprite sprite2White;
    public Sprite sprite3Black;
    public Sprite sprite3White;
    public Sprite sprite4Black;
    public Sprite sprite4White;

    private void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<MEeditManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (stayTime == -1 && manager.canTouch)
        {
            stayTime = 0.152f;
        }
        else if (stayTime > 0 && manager.canTouch)
        {
            stayTime = -1;
            if (condition == 0)
            {
                condition = 1;
                if (type == -1)
                {
                    spriteRenderer.sprite = sprite_1Black;
                }
                else if (type == 0)
                {
                    spriteRenderer.sprite = sprite1Black;
                }
                else if (type == 1)
                {
                    spriteRenderer.sprite = sprite2Black;
                }
                else if (type == 2)
                {
                    spriteRenderer.sprite = sprite3Black;
                }
                else if (type == 3)
                {
                    spriteRenderer.sprite = sprite4Black;
                }
            }
            else if (condition == 2 || condition == 1)
            {
                if (condition == 1)
                {
                    condition = 2;
                    spriteRenderer.color = new Color(1, 1, 1, 0.12f);
                }
                else
                {
                    condition = 0;
                    spriteRenderer.color = new Color(1, 1, 1, 1);
                }
                if (type == -1)
                {
                    spriteRenderer.sprite = sprite_1White;
                }
                else if (type == 0)
                {
                    spriteRenderer.sprite = sprite1White;
                }
                else if (type == 1)
                {
                    spriteRenderer.sprite = sprite2White;
                }
                else if (type == 2)
                {
                    spriteRenderer.sprite = sprite3White;
                }
                else if (type == 3)
                {
                    spriteRenderer.sprite = sprite4White;
                }
            }
        }
    }

    private void Update()
    {
        if (stayTime != -1)
        {
            stayTime -= Time.deltaTime;
            if (stayTime <= 0)
            {
                stayTime = -1;
                if (manager.canTouch)
                {
                    if (type == -1)
                    {
                        type = 0;
                        if (condition == 0 || condition == 2)
                        {
                            spriteRenderer.sprite = sprite1White;
                        }
                        else if (condition == 1)
                        {
                            spriteRenderer.sprite = sprite1Black;
                        }
                    }
                    else if (type == 0)
                    {
                        type = 1;
                        if (condition == 0 || condition == 2)
                        {
                            spriteRenderer.sprite = sprite2White;
                        }
                        else if (condition == 1)
                        {
                            spriteRenderer.sprite = sprite2Black;
                        }
                    }
                    else if (type == 1)
                    {
                        type = 2;
                        if (condition == 0 || condition == 2)
                        {
                            spriteRenderer.sprite = sprite3White;
                        }
                        else if (condition == 1)
                        {
                            spriteRenderer.sprite = sprite3Black;
                        }
                    }
                    else if (type == 2)
                    {
                        type = 3;
                        if (condition == 0 || condition == 2)
                        {
                            spriteRenderer.sprite = sprite4White;
                        }
                        else if (condition == 1)
                        {
                            spriteRenderer.sprite = sprite4Black;
                        }
                    }
                    else if (type == 3)
                    {
                        type = -1;
                        if (condition == 0 || condition == 2)
                        {
                            spriteRenderer.sprite = sprite_1White;
                        }
                        else if (condition == 1)
                        {
                            spriteRenderer.sprite = sprite_1Black;
                        }
                    }
                }
            }
        }
    }
}
