using System.Collections;
using UnityEngine;

namespace JungleFrog.Player
{
    public class ClickDetector : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        Player player;


        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0))
            {
                player.Shoot();
            }
        }
    }
}