using System.Collections;
using UnityEngine;
using JungleFrog.Player;
using TMPro;

namespace JungleFrog
{
    public enum PlayerFieldPosition
    {
        TOP,
        BOTTOM,
    }

    public class Game : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        TextMeshProUGUI scoreText;

        int playerTopScore;
        int playerBottomScore;


        private void Awake()
        {
            playerTopScore = playerTopScore = 0;
            UpdateText();
        }

        void UpdateText()
        {
            scoreText.text = $"{playerTopScore} - {playerBottomScore}";
        }

        public void AddScore(PlayerFieldPosition position)
        {
            if (position == PlayerFieldPosition.TOP)
            {
                playerTopScore++;
            }
            else
            {
                playerBottomScore++;
            }

            UpdateText();
        }
    }
}