using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public List<Body> bodies;
    public Food food;
    public GameManager gameManager;
    public Color nowColor = new Color(1, 1, 1);

    private int moveDir = 0;
    private int lastMoveDir = 4;
    private int sunMoveDir = 0;
    private float foodScale = 1;

    public float playerColor = 0;
    private int playerColorPattern = 0;

    public void Start()
    {

    }

    public void Update()
    {
        KeyEvent();
        SetFoodScale();
    }

    public void Notify()
    {
        if (moveDir == 0)
            return;

        KeyEvent();

        int lastX = bodies[0].x;
        int lastY = bodies[0].y;
        lastMoveDir = moveDir;

        Move();
        Eat(lastX, lastY);
        SetScale();

        if (sunMoveDir != -1)
            moveDir = sunMoveDir;
        sunMoveDir = -1;
    }

    private void Move()
    {
        for (int i = 0; i < bodies.Count; i++)
        {
            if (i == bodies.Count - 1) // 마지막 몸일 경우
            {
                if (moveDir == 1) // w
                {
                    bodies[i].y += 1;
                }
                else if (moveDir == 2) // s
                {
                    bodies[i].y += -1;
                }
                else if (moveDir == 3) // a
                {
                    bodies[i].x += -1;
                }
                else if (moveDir == 4) // d
                {
                    bodies[i].x += 1;
                }
            }
            else
            {
                bodies[i].x = bodies[i + 1].x;
                bodies[i].y = bodies[i + 1].y;
            }

            bodies[i].transform.position = new Vector3(bodies[i].x, bodies[i].y, 0);
        }

        GameOverCheck();
    }

    private void GameOverCheck()
    {
        if (bodies[bodies.Count - 1].x < -12 || bodies[bodies.Count - 1].x > 12
            || bodies[bodies.Count - 1].y < -6 || bodies[bodies.Count - 1].y > 6)
        {
            gameManager.GameOver();
            Destroy(food.gameObject);
        }

        for (int i = 0; i < bodies.Count - 1; i++)
        {
            if (bodies[i].x == bodies[bodies.Count - 1].x
                && bodies[i].y == bodies[bodies.Count - 1].y)
            {
                gameManager.GameOver();
                Destroy(food.gameObject);
                break;
            }
        }
    }

    private void SetFoodScale()
    {
        if (gameManager.isGameOver)
            return;

        foodScale += Time.deltaTime / 8 / gameManager.behaviourInterval;
        if (foodScale >= 1.5f)
        {
            foodScale = 0.5f;
        }
        food.transform.localScale = new Vector3(foodScale, foodScale, 1);
    }

    private void SetScale()
    {
        float localScale = 1.5f;

        for (int i = bodies.Count - 1; i >= 0; i--)
        {
            localScale -= 0.15f;
            if (localScale <= 0.5f)
            {
                localScale = 1.5f;
            }

            bodies[i].transform.localScale = new Vector3(localScale, localScale, 1);
        }
    }

    private void Eat(int lastX, int lastY)
    {
        if (food.x == bodies[bodies.Count - 1].x
            && food.y == bodies[bodies.Count - 1].y)
        {
            bool isExit = false;
            gameManager.AddScore(1);
            gameManager.Faster();

            while (!isExit)
            {
                isExit = true;

                food.x = UnityEngine.Random.Range(-12, 13);
                food.y = UnityEngine.Random.Range(-6, 7);

                foreach (var body_ in bodies)
                {
                    if (body_.x == food.x && body_.y == food.y)
                    {
                        isExit = false;
                    }
                }

                if (isExit)
                {
                    food.transform.position = new Vector3(food.x, food.y, 0);

                    var newBody = Instantiate(gameManager.bodyPrefab);
                    newBody.transform.position = new Vector3(lastX, lastY, 0);
                    newBody.transform.SetParent(gameManager.player.transform);
                    newBody.name = "body";

                    var body = newBody.GetComponent<Body>();
                    body.x = lastX;
                    body.y = lastY;

                    bodies.Insert(0, body);
                }
            }
        }
    }

    private void KeyEvent()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            && moveDir != 1)
        {
            sunMoveDir = 1;
        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            && moveDir != 2)
        {
            sunMoveDir = 2;
        }
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            && moveDir != 3)
        {
            sunMoveDir = 3;
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            && moveDir != 4)
        {
            sunMoveDir = 4;
        }


        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            && lastMoveDir != 2)
        {
            moveDir = 1;
        }
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            && lastMoveDir != 1)
        {
            moveDir = 2;
        }
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            && lastMoveDir != 4)
        {
            moveDir = 3;
        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            && lastMoveDir != 3)
        {
            moveDir = 4;
        }
    }

    public void PlayerColorUpdate()
    {
        if (!gameManager.isPlayerColorUpdate)
            return;

        playerColor += Time.deltaTime / 8 / gameManager.behaviourInterval;
        if (playerColor >= 1)
        {
            playerColor = 0;
            playerColorPattern = (playerColorPattern + 1) % 6;
            gameManager.isPlayerColorUpdate = false;
        }

        foreach (var element in bodies)
        {
            if (playerColorPattern == 0)
            {
                nowColor = new Color(0.8f, 0.3f, 0.3f + (playerColor * 0.5f));
            }
            else if (playerColorPattern == 1)
            {
                nowColor = new Color(0.8f - (playerColor * 0.5f), 0.3f, 0.8f);
            }
            else if (playerColorPattern == 2)
            {
                nowColor = new Color(0.3f, 0.3f + (playerColor * 0.5f), 0.8f);
            }
            else if (playerColorPattern == 3)
            {
                nowColor = new Color(0.3f, 0.8f, 0.8f - (playerColor * 0.5f));
            }
            else if (playerColorPattern == 4)
            {
                nowColor = new Color(0.3f + (playerColor * 0.5f), 0.8f, 0.3f);
            }
            else if (playerColorPattern == 5)
            {
                nowColor = new Color(0.8f, 0.8f - (playerColor * 0.5f), 0.3f);
            }

            if (element.spriteRenderer != null)
            {
                element.spriteRenderer.color = nowColor;
                food.spriteRenderer.color = nowColor;
            }
        }
    }
}
