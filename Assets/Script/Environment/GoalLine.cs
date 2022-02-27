using System;
using UnityEngine;
using JungleFrog.Audio;
using TMPro;

namespace JungleFrog.Environment
{
    public class GoalLine : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        Player.Player player;
        [SerializeField]
        TextMeshProUGUI playerName;


        public void SetText(string text)
        {
            this.playerName.text = text;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Ball.Ball ball = collision.GetComponent<Ball.Ball>();

            if (ball != null)
            {
                player.GoalTaken();
                ball.ResetPosition();
                AudioManager.Play(SoundEffect.Goal);
            }
        }
    }
}