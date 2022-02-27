using System;
using UnityEngine;
using JungleFrog;
using JungleFrog.Environment;

namespace JungleFrog.Player
{
    public class Player : MonoBehaviour
    {
        const string FireTrigger = "Fire";

        [Header("Setup")]
        [SerializeField]
        Game game;
        [SerializeField]
        SpriteRenderer spriteRender;
        [SerializeField]
        Cannon.Cannon cannon;
        [SerializeField]
        GoalLine goalLine;
        [SerializeField]
        Animator animator;

        [Header("GD.Position")]
        [SerializeField]
        PlayerFieldPosition fieldPosition;

        [Header("GD")]
        [SerializeField]
        string playerName = "Player";
        [SerializeField]
        float rotation;

        private void Start()
        {
            goalLine.SetText(playerName);
        }

        internal void GoalTaken()
        {
            game.AddScore(fieldPosition);
        }

        public void Shoot()
        {
            if (cannon.Shoot())
            {
                animator.SetTrigger(FireTrigger);
            }
        }

        private void FixedUpdate()
        {
            spriteRender.transform.Rotate(0, 0, rotation);
        }
    }
}