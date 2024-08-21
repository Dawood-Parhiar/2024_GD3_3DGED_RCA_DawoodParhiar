using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GD.My_Game_Project.My_Assets.Scripts.UI
{
    public class CountdownTimer : MonoBehaviour
    {
        [SerializeField]
        public TMP_Text timerText;
        
        [SerializeField]
        [Header("Time in seconds for one game")]
        private float countdownTime = 120f; // 2 minutes in seconds

        [SerializeField]
        private Button restartButton;
        
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
                Managers.GameManager.Instance.GameOver(); // Stop the game
            }
        }
        public void OnRestartButtonClick()
        {
            //Application reload
            Managers.GameManager.Instance.RestartLevel();
        }
    
    }
}