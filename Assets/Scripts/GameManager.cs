using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    }
    public GameObject RetryButton;
    public Text LevelText;
    public RectTransform LevelFront;
    public GameObject NormalCat;
    public GameObject FatCat;
    public GameObject PirateCat;

    int _level = 0;
    int _score = 0;

    void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1.0f);
    }
    void MakeCat()
    {
        Instantiate(NormalCat);
        // Level 1 20프로 확률로 고양이 더 생성
        // Level 2 50프로 확률로 고양이 더 생성
        // Level 3 Fat Cat 생성
        int p = Random.Range(0, 10);

        if (_level == 1)
        {
            if (p < 2) Instantiate(NormalCat);
        }
        else if (_level == 2)
        {
            if (p < 5) Instantiate(NormalCat);
        }
        else if (_level == 3)
        {
            Instantiate(FatCat);
        }
        else if (_level >= 4)
        {
            Instantiate(PirateCat);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        RetryButton.SetActive(true);
    }

    public void AddScore()
    {
        _score++;
        _level = _score / 5;
        LevelText.text = _level.ToString();
        LevelFront.localScale = new Vector3(_score % 5 / 5.0f, 1f, 1f);
    }
}
