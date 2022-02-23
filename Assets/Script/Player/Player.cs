using System.Collections;
using UnityEngine;

namespace JungleFrog.Cannon
{
    public class Player : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        Cannon cannon;

        [Header("GD")]
        [SerializeField]
        float rotation;



        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                cannon.Shoot();
            }
        }

        private void FixedUpdate()
        {
            transform.Rotate(0, 0, rotation);
        }
    }
}