using GD.My_Game_Project.My_Assets.Scripts.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GD.My_Game_Project.My_Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("Player")]
        [SerializeField] private GameObject playerPrefab;
        private GameObject playerInstance;

        [Header("Audio")]
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private GameObject audioSourceHolder;

        private enum GameState { Start, Playing, Paused, GameOver }
        private GameState currentState;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            InitializeGame();
        }

        private void InitializeGame()
        {
            currentState = GameState.Start;
            SpawnPlayer();
            InitializeAudio();
        }

        private void SpawnPlayer()
        {
            if (playerPrefab != null)
            {
                playerInstance = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            }
        }

        private void InitializeAudio()
        {
            if (audioManager != null && audioSourceHolder != null)
            {
                audioManager.Initialize(audioSourceHolder);
                audioManager.PlayBackgroundMusic();
            }
        }

        public void StartGame()
        {
            currentState = GameState.Playing;
            // Additional start game logic
            
            
        }

        public void PauseGame()
        {
            currentState = GameState.Paused;
            Time.timeScale = 0;
            // Additional pause game logic
        }

        public void ResumeGame()
        {
            currentState = GameState.Playing;
            Time.timeScale = 1;
            // Additional resume game logic
        }

        public void GameOver()
        {
            currentState = GameState.GameOver;
            // Additional game over logic
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            InitializeGame();
        }

        public void LoadNextLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
            InitializeGame();
        }
    }
}