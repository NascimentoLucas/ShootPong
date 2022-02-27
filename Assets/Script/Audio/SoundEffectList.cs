using System;
using System.Collections;
using UnityEngine;


namespace JungleFrog.Audio
{
    [CreateAssetMenu(fileName = "SoundEffectList", menuName = "ScriptableObjects/SoundEffectList", order = 1)]
    public class SoundEffectList : ScriptableObject
    {
        [Header("Setup")]
        [SerializeField]
        AudioObject[] effects;

        internal AudioClip GetEffect(SoundEffect effect)
        {
            return effects[(int)effect].GetClip();
        }
    }
}