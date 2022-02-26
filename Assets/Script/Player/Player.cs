using System.Collections;
using UnityEngine;
using JungleFrog.Cannon;
using JungleFrog.Environment;
using System;

namespace JungleFrog.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        SpriteRenderer spriteRender;
        [SerializeField]
        Cannon.Cannon cannon;
        [SerializeField]
        GoalLine goalLine;

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
            Debug.Log("Goal");
        }

        public void PlayerShoot()
        {
            cannon.Shoot();
        }

        private void FixedUpdate()
        {
            spriteRender.transform.Rotate(0, 0, rotation);
        }
    }
}