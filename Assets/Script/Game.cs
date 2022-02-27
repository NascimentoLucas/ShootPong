using System;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        TextMeshProUGUI topScoreText;
        [SerializeField]
        TextMeshProUGUI bottomScoreText;


        [Header("Setup.UI")]
        [SerializeField]
        RectTransform tutorialUI;
        [SerializeField]
        RectTransform confirmQuitUI;


        int playerTopScore;
        int playerBottomScore;


        private void Awake()
        {
            playerTopScore = playerTopScore = 0;
            UpdateText();

#if UNITY_EDITOR
            return;
#endif
            tutorialUI.gameObject.SetActive(true);
            confirmQuitUI.gameObject.SetActive(false);
        }

        void UpdateText()
        {
            topScoreText.text = $"{playerTopScore}";
            bottomScoreText.text = $"{playerBottomScore}";
        }

        public void AddScore(PlayerFieldPosition position)
        {
            if (position != PlayerFieldPosition.TOP)
            {
                playerTopScore++;
            }
            else
            {
                playerBottomScore++;
            }

            UpdateText();
        }

        public void Quit()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        public void ResetScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}