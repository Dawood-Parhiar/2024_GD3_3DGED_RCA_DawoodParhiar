using UnityEngine;
using UnityEngine.Audio;

namespace GD.My_Game_Project.My_Assets.Scripts.Audio
{
    [CreateAssetMenu(fileName = "AudioManager", menuName = "My Scriptable Objects/AudioManager", order = 1)]
    public class AudioManager : ScriptableObject
    {
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private AudioMixerGroup backgroundMusicGroup;
        [SerializeField] private AudioClip backgroundMusicClip;

        private AudioSource backgroundMusicSource;

        public void Initialize(GameObject audioSourceHolder)
        {
            backgroundMusicSource = audioSourceHolder.AddComponent<AudioSource>();
            backgroundMusicSource.outputAudioMixerGroup = backgroundMusicGroup;
            backgroundMusicSource.loop = true;
        }

        public void PlayBackgroundMusic()
        {
            if (backgroundMusicClip != null && backgroundMusicSource != null)
            {
                    backgroundMusicSource.clip = backgroundMusicClip;
                    backgroundMusicSource.Play();
            }
        }
    }
}