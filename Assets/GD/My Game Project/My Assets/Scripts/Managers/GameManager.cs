using System.Collections;
using GD.My_Game_Project.My_Assets.Scripts.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GD.My_Game_Project.My_Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        private GameObject playerInstance;

        [Header("UI")]
        [SerializeField] private GameObject gameOverText;
        [SerializeField] private GameObject mainMenu;
        [SerializeField] private GameObject winningText;
        
        [Header("Audio")]
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private AudioSource winMusic;
        public enum GameState { Start, Playing, Paused, GameOver }

        public GameState CurrentState { get; private set; }
        
        
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
            gameOverText.SetActive(false);
            mainMenu.SetActive(true);
            winningText.SetActive(false);
        }

        private void InitializeGame()
        {
            CurrentState = GameState.Start;
            //SpawnPlayer();
            InitializeAudio();
        }

        void Update()
        {
            if (CurrentState == GameState.Playing)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    PauseGame();
                    CurrentState = GameState.Paused;
                    mainMenu.SetActive(true);
                }else if(CurrentState == GameState.Paused && Input.GetKeyDown(KeyCode.Escape))
                {
                    ResumeGame();
                    CurrentState = GameState.Playing;
                    mainMenu.SetActive(false);
                }
            }
        }
        // private void SpawnPlayer()
        // {
        //     if (playerPrefab != null)
        //     {
        //         playerInstance = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        //     }
        // }

        private void InitializeAudio()
        {
            if (audioManager != null)
            {
                audioManager.Initialize();
                audioManager.PlayBackgroundMusic();
            }
        }

        public void StartGame()
        {
            CurrentState = GameState.Playing;
        }

        public void PauseGame()
        {
            CurrentState = GameState.Paused;
            Time.timeScale = 0;
            //stop music
            AudioListener.pause = true;
        }

        public void ResumeGame()
        {
            CurrentState = GameState.Playing;
            Time.timeScale = 1;
            AudioListener.pause = false;
           
        }

        public void GameOver()
        {
            CurrentState = GameState.GameOver;
            Time.timeScale = 0;
            gameOverText.SetActive(true);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            InitializeGame();
        }
        
        public void GameWon()
        {
            winningText.SetActive(true);
            if(winMusic != null)//If we have a win music
            {
                winMusic.Play();
            }
            StartCoroutine(HandleGameWon());
        }

        private IEnumerator HandleGameWon()
        {
            //Wait for 5 seconds and then show main menu
            yield return new WaitForSeconds(5);
            winningText.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}