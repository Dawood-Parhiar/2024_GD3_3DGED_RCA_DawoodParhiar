using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public TMP_Text timerText;
    [SerializeField]
    public GameObject gameOverText;
    [SerializeField]
    [Header("Time in seconds for one game")]
    private float countdownTime = 120f; // 2 minutes in seconds

    void Start()
    {
        gameOverText.SetActive(false); // Hide the Game Over text initially
    }

    void Update()
    {
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(countdownTime / 60);
            int seconds = Mathf.FloorToInt(countdownTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            gameOverText.SetActive(true); // Show the Game Over text
            timerText.enabled = false; // Hide the timer text
            Time.timeScale = 0; // Stop the game
        }
    }
}