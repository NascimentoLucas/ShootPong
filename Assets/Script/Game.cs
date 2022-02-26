using System.Collections;
using UnityEngine;
using JungleFrog.Player;

namespace Assets.Script
{
    public class Game : MonoBehaviour
    {
        Player[] players;


        int currentPlayer;

        private void Awake()
        {
            players = FindObjectsOfType<Player>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                players[currentPlayer].PlayerShoot();

                currentPlayer++;
                if (currentPlayer > players.Length - 1)
                    currentPlayer = 0;
            }
        }
    }
}