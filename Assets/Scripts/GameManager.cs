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
    public GameObject NormalCat;
    public GameObject RetryButton;
    public Text LevelText;
    public RectTransform LevelFront;

    int _level = 0;
    int _score = 0;

    void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1.0f);
    }
    void MakeCat()
    {
        Instantiate(NormalCat);
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
