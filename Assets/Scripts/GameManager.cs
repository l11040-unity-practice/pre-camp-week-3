using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        InvokeRepeating("MakeCat", 0f, 1.0f);
    }
    void Update()
    {

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
}
