﻿using System.Collections;
using UnityEngine;
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
            player.GoalTaken();
        }
    }
}