﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject obstacle;

    public float spawnTime;
    float m_spawnTime;
    int m_score;
    bool m_isGameover;

    UIManager m_ui;
    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UIManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        //Va chạm với chướng ngại vật =>Gameover k tạo thêm cnv
        if (m_isGameover)
        {
            m_spawnTime = 0;
            m_ui.ShowGameoverPanel(true);
            return;
        }
        m_spawnTime -= Time.deltaTime;

        if(m_spawnTime <= 0)
        {
            SpawnObstacle();
            m_spawnTime = spawnTime;
        }
    }
    //Tạo chướng ngại vật
    public void SpawnObstacle()
    {
        float randYpos = Random.Range(-1.8f,-0.7f);
        //Vị trí tạo chướng ngại vật
        Vector2 spawnPos = new Vector2(9.6f,randYpos);
        if (obstacle)
        {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
        }
    }
    public void SetScore(int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }

    //Tăng điểm 
    public void ScoreIncrement()
    {
        if (m_isGameover)
        {
            return;
        }
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }
    public bool IsGameover()
    {
        return m_isGameover;
    }

    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }
    //Replay game
    public void Replay()
    {
        //Tải lại scene
        SceneManager.LoadScene("Gameplay");
    }
}
