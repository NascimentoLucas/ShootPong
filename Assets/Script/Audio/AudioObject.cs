using System;
using UnityEngine;

namespace JungleFrog.Audio
{
    [Serializable]
    public class AudioObject 
    {
        [SerializeField]
        AudioClip[] audioClips;


        public AudioClip GetClip()
        {
            return audioClips[UnityEngine.Random.Range(0, audioClips.Length)];
        }
    }
}