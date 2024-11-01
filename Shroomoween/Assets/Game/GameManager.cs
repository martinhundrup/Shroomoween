using NUnit.Framework;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Game Speed")]
    [SerializeField] private float baseSpeed = 2f;           // Initial speed of the game
    [SerializeField] private float speedIncreaseRate = 0.1f; // Rate at which the speed increases over time
    [SerializeField] private float maxSpeed = 20f;           // Maximum speed to limit the increase

    [Header("Score")]
    [SerializeField] private float scoreMultiplier;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI info;
    [SerializeField] private TextMeshProUGUI restart;



    private void Awake()
    {
        GameStats.OnGameRestart += OnRestart;
        GameStats.GameSpeed = baseSpeed;
        GameStats.Score = 0;
        GameStats.Ammo = 3;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && GameStats.GameStart)
        {
            GameStats.RestartGame();
        }

        if (Input.GetButtonDown("Jump") && !GameStats.GameStart)
        {
            FindFirstObjectByType<CameraFollower>().FollowPlayer = false;
            GameStats.GameStart = true;
            title.enabled = false;
            info.enabled = false;
            restart.enabled = false;
            GameStats.GameSpeed = baseSpeed;
        }
            

        if (GameStats.GameOver || !GameStats.GameStart)
        {
            restart.enabled = true;
            GameStats.GameSpeed = 0;
            return; // don't move stuff while game over or before start
        }
            

        // score
        GameStats.Score += Time.deltaTime * scoreMultiplier * GameStats.GameSpeed;

        // speed
        if (GameStats.GameSpeed < maxSpeed)
        {
            GameStats.GameSpeed += speedIncreaseRate * Time.deltaTime;
        }

        

        //Debug.Log("Current Speed: " + stats.GameSpeed);
    }

    private void OnRestart()
    {
        GameStats.GameOver = false;
        title.enabled = false;
        info.enabled = false;
        restart.enabled = false;
        GameStats.GameSpeed = baseSpeed;
        GameStats.Score = 0;
        GameStats.Ammo = 3;
    }
}
