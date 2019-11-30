using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject bodyPrefab;
    public GameObject player;
    public GameObject wall;
    public GameObject walls;
    public AudioSource audio;
    public PlayerManager playerManager;
    public Camera camera;
    public float behaviourInterval = 0.5f;
    public int score = 0;
    public bool isGameOver = false;
    public bool isPlayerColorUpdate = false;

    public GameObject button;
    public Text buttonText1;
    public Text buttonText2;

    public RectTransform textTransform;
    public Text text;

    private List<GameObject> wallList;
    private float time = 0;
    private float gameOverTime = 0;
    private int camColorPattern = 0;
    private float camZoom = 7.5f;
    private float camColor = 0;
    private float textAngle = 0;
    private int fasterCount = 0;
    private bool isButtonActivate = false;
    private bool isCameraUpdate = false;
    private bool isCameraZoom = false;

    void Start()
    {
        wallList = new List<GameObject>();
        playerManager.bodies = new List<Body>();

        for (int i = 0; i < 3; i++)
        {
            var newBody = Instantiate(bodyPrefab);
            newBody.transform.position = new Vector3(i - 7, 0, 0);
            newBody.transform.SetParent(player.transform);
            newBody.name = "body";

            var body = newBody.GetComponent<Body>();
            body.x = i - 7;

            playerManager.bodies.Add(body);
        }

        for (int i = -14; i <= 14; i++)
        {
            for (int j = -8; j <= 8; j++)
            {
                if (i < -12 || i > 12 || j < -6 || j > 6)
                {
                    var newWall = Instantiate(bodyPrefab);
                    newWall.transform.position = new Vector3(i, j, 0);
                    newWall.transform.SetParent(walls.transform);
                    newWall.transform.localScale = new Vector3(1.6f, 1.6f, 1);
                    newWall.name = "wall";
                    newWall.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);

                    wallList.Add(newWall);
                }
            }
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            time += Time.deltaTime;
            if (time >= behaviourInterval)
            {
                time -= behaviourInterval;

                playerManager.Notify();
            }

            TextUpdate();
            CameraUpdate();
            CameraZoom();
            playerManager.PlayerColorUpdate();
        }
        else
        {
            GameOverUpdate();

            if (Input.GetMouseButtonDown(0))
                Return();
        }

        if (score >= 30)
        {
            camera.backgroundColor = new Color(1, 1, 1, 1);
        }
    }

    private void CameraZoom()
    {
        if (!isCameraZoom && score >= 30)
        {
            camZoom += Time.deltaTime * 1.4f;
            if (camZoom >= 8f)
            {
                camZoom = 7.5f;
            }

            if (camZoom >= 7.7f)
                camera.orthographicSize = camZoom;
            else
                camera.orthographicSize = 7.7f;
        }
        else if (isCameraZoom && score < 30)
        {
            camZoom += Time.deltaTime * 1.4f;
            if (camZoom >= 8f)
            {
                camZoom = 8f;
                isCameraZoom = false;
            }
            camera.orthographicSize = camZoom;
        }
    }

    private void GameOverUpdate()
    {
        gameOverTime += Time.deltaTime;
        if (gameOverTime >= 2)
        {
            gameOverTime = 2;
        }

        // 소리 사라짐
        audio.volume = 1 - gameOverTime / 2;

        // 카메라 줌
        if (gameOverTime <= 1)
        {
            camZoom += Time.deltaTime * 2;
            if (camZoom >= 8f)
            {
                camZoom = 8f;
            }
            camera.orthographicSize = camZoom;
        }
        else
        {
            camera.orthographicSize = 8 - (gameOverTime - 1) * 4.5f;
        }

        // 카메라 회전
        if (gameOverTime >= 1)
        {
            camera.transform.eulerAngles = new Vector3(0, 0, (gameOverTime - 1) * -14);
        }

        // 플레이어 반투명
        if (gameOverTime >= 1)
        {
            foreach (var body in playerManager.bodies)
            {
                var comp = body.GetComponent<SpriteRenderer>();
                comp.color = new Color(
                    comp.color.r, comp.color.g, comp.color.b, (2 - gameOverTime));
            }
        }

        // 텍스트 회전
        if (gameOverTime <= 1
            && textAngle != 0)
        {
            textAngle += Time.deltaTime * 3;
            if (textAngle >= Math.PI * 2)
            {
                textAngle = 0;
            }

            textTransform.eulerAngles = new Vector3(0, 0, (float)Math.Sin(textAngle) * 15);
        }

        // 버튼 나타남
        if (gameOverTime >= 1)
        {
            if (isButtonActivate == false)
            {
                button.SetActive(true);
                isButtonActivate = true;
            }

            if (score >= 30)
            {
                buttonText1.color = new Color(0, 0, 0, gameOverTime - 1);
                buttonText2.color = new Color(0, 0, 0, gameOverTime - 1);
            }
            else
            {
                buttonText1.color = new Color(1, 1, 1, gameOverTime - 1);
                buttonText2.color = new Color(1, 1, 1, gameOverTime - 1);
            }
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        camZoom = 7.5f;
    }

    private void TextUpdate()
    {
        textAngle += Time.deltaTime / 8 / behaviourInterval;
        if (textAngle >= Math.PI * 2)
        {
            textAngle = 0;
        }

        textTransform.eulerAngles = new Vector3(0, 0, (float)Math.Sin(textAngle) * 15);
    }

    private void CameraUpdate()
    {
        if (!isCameraUpdate)
            return;

        camColor += Time.deltaTime / 8 / behaviourInterval;
        if (camColor >= 1)
        {
            camColor = 0;
            camColorPattern = (camColorPattern + 1) % 6;
            isCameraUpdate = false;
        }

        if (score >= 30)
        {
        }
        if (camColorPattern == 0)
        {
            camera.backgroundColor = new Color(0.8f, 0.3f, 0.3f + (camColor * 0.5f));
        }
        else if (camColorPattern == 1)
        {
            camera.backgroundColor = new Color(0.8f - (camColor * 0.5f), 0.3f, 0.8f);
        }
        else if (camColorPattern == 2)
        {
            camera.backgroundColor = new Color(0.3f, 0.3f + (camColor * 0.5f), 0.8f);
        }
        else if (camColorPattern == 3)
        {
            camera.backgroundColor = new Color(0.3f, 0.8f, 0.8f - (camColor * 0.5f));
        }
        else if (camColorPattern == 4)
        {
            camera.backgroundColor = new Color(0.3f + (camColor * 0.5f), 0.8f, 0.3f);
        }
        else if (camColorPattern == 5)
        {
            camera.backgroundColor = new Color(0.8f, 0.8f - (camColor * 0.5f), 0.3f);
        }
    }

    public void AddScore(int i)
    {
        score += i;
        text.text = score + "";
        if (score >= 30)
        {
            if (score == 30)
            {
                camera.backgroundColor = new Color(1, 1, 1);
                audio.pitch = 1.4f;
            }
            isPlayerColorUpdate = true;
        }
        else
        {
            audio.pitch = 1 + score / 100f;
            isCameraUpdate = true;
        }

        if (score % 3 == 0
            && score < 30)
        {
            isCameraZoom = true;
            camZoom = 7.5f;
        }
    }

    public void Faster()
    {
        fasterCount++;
        if (fasterCount >= 3)
        {
            fasterCount = 0;

            behaviourInterval -= 0.01f;
            if (behaviourInterval <= 0.05f)
            {
                behaviourInterval = 0.05f;
            }
        }
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }
}
