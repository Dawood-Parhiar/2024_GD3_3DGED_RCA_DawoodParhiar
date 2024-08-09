using UnityEngine;
using GD.My_Game_Project.My_Assets.Scripts.Audio;

public class AudioManagerInitializer : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;

    void Start()
    {
        if (audioManager != null)
        {
            audioManager.Initialize(gameObject);
            audioManager.PlayBackgroundMusic();
        }
    }
}