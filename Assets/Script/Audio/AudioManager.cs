using System.Collections;
using UnityEngine;

namespace JungleFrog.Audio
{
    public enum SoundEffect
    {
        BallTouched,
        Goal,
    }

    public class AudioManager : MonoBehaviour
    {
        static AudioManager Singleton;

        [Header("Setup")]
        [SerializeField]
        AudioSource[] audioSources;
        [SerializeField]
        SoundEffectList soundEffectList;

        int currentAudioSource = 0;

        AudioSource CurrentAudioSource { get => audioSources[currentAudioSource]; }

        private void Awake()
        {
            Singleton = this;
        }

        void PlayEffect(SoundEffect effect)
        {
            CurrentAudioSource.Stop();
            CurrentAudioSource.clip = soundEffectList.GetEffect(effect);
            CurrentAudioSource.Play();
            NextAudioSource();
        }

        private void NextAudioSource()
        {
            currentAudioSource++;
            if (currentAudioSource > audioSources.Length - 1)
                currentAudioSource = 0;
        }

        public static void Play(SoundEffect effect)
        {
            if (Singleton == null) return;
            Singleton.PlayEffect(effect);
        }

    }
}