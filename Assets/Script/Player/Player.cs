using System.Collections;
using UnityEngine;
using JungleFrog.Cannon;

namespace JungleFrog.Player
{
    public class Player : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        Cannon.Cannon cannon;

        [Header("GD")]
        [SerializeField]
        float rotation;
              

        public void PlayerShoot()
        {
            cannon.Shoot();
        }

        private void FixedUpdate()
        {
            transform.Rotate(0, 0, rotation);
        }
    }
}