using System;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Stores data relating to a complete game (i.e. multiple levels)
/// </summary>
/// <see cref="https://blogs.unity3d.com/2020/07/01/achieve-better-scene-workflow-with-scriptableobjects/"/>
namespace GD
{
    [CreateAssetMenu(fileName = "GameLayout", menuName = "DkIT/Scriptable Objects/Game/Layout", order = 1)]
    public class GameLayout : ScriptableGameObject
    {
        #region Title & Level Layout

        [Header("Title")]
        public string Title;

        [Header("Level Layout")]
        public List<GameLevel> Levels;

        [Min(0)]
        [Tooltip("Zero-based index in the list of level layouts for the start level in the game (e.g. 0)")]
        public int StartLevel;

        [ReadOnly]
        public bool isStartLoaded;

        [ReadOnly]
        public int CurrentLevel;

        #endregion Title & Level Layout

        #region Menu

        [Header("Menu Layout")]
        public GameScene MainMenu;

        public GameScene PauseMenu;
        public GameScene UIMenu;

        #endregion Menu

        #region Development Team & Version

        [Header("Development Team")]
        public string ProductOwner;

        public string TeamLead;
        public string TestLead;
        public List<TeamMember> TeamMembers;

        [Space(10)]
        [Header("Version & Documentation (optional)")]
        public LifecycleStage Stage;

        [Min(1)]
        public float Version;

        public string RepositoryURL;

        #endregion Development Team & Version

        [ContextMenu("Load Level")]
        public void LoadLayout()
        {
            if (Levels.Count == 0)
                return;

            Levels[StartLevel].LoadLevel();

            isStartLoaded = true;
        }

        [ContextMenu("Unload Level")]
        public void UnloadLayout()
        {
            if (Levels.Count == 0)
                return;

            Levels[StartLevel].UnloadLevel();

            isStartLoaded = false;
        }

        #region TODO

        //TODO
        public void NextLevel()
        {
            //load next level
        }

        //Restart current level
        public void RestartLevel()
        {
            //reset
        }

        //New game, load level 1
        public void NewGame()
        {
            //set current back to start level
        }

        public void LoadMainMenu()
        {
            // SceneManager.LoadSceneAsync(/*main name*/);
        }

        public void LoadPauseMenu()
        {
            // SceneManager.LoadSceneAsync(/*pause name*/);
        }

        public void SaveGame()
        {
            // AssetDatabase
        }

        #endregion TODO
    }
}