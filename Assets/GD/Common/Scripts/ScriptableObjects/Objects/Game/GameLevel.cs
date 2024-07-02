using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// Stores data relating to a level comprised of multiple scenes
/// </summary>
/// <see cref="https://blogs.unity3d.com/2020/07/01/achieve-better-scene-workflow-with-scriptableobjects/"/>
namespace GD
{
    [CreateAssetMenu(fileName = "GameLevel", menuName = "DkIT/Scriptable Objects/Game/Level", order = 2)]
    public class GameLevel : ScriptableGameObject
    {
        [Space]
        [Header("Scenes")]
        public List<GameScene> Scenes;

        [Space]
        [Header("Level Objectives (optional)")]
        public List<GameObjective> Objectives;

        [Space]
        [Header("Post-processing(optional")]
        public bool UseDefaultPostProcessingVolume = false;

        public Volume PostProcessPrefab;

        public VolumeProfile DefaultPostProcessProfile;

        //internal
        private Volume instancePostProcessPrefab;

        public void LoadLevel()
        {
            foreach (GameScene scene in Scenes)
                scene.LoadScene();

            if (PostProcessPrefab != null && DefaultPostProcessProfile != null)
            {
                instancePostProcessPrefab = Instantiate(PostProcessPrefab);
                instancePostProcessPrefab.profile = DefaultPostProcessProfile;
            }
        }

        public void UnloadLevel()
        {
            foreach (GameScene scene in Scenes)
                scene.UnloadScene();

            if (instancePostProcessPrefab != null)
                Destroy(instancePostProcessPrefab);
        }
    }
}