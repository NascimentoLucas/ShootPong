using System.Collections;
using UnityEngine;

namespace JungleFrog.Player
{
    public class ClickDetector : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        private Collider collider;
        [SerializeField]
        Player player;


        private void Update()
        {
            Touch touch;
            Vector3 pos;
            for (int i = 0; i < Input.touchCount; i++)
            {
                touch = Input.GetTouch(i);
                pos = Camera.main.ScreenToWorldPoint(touch.position);
                pos.z = collider.bounds.center.z;
                if (collider.bounds.Contains(pos))
                {
                    player.Shoot();
                    return;
                }
            }

#if UNITY_EDITOR

            if (Input.GetMouseButtonDown(0))
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = collider.bounds.center.z;
                if (collider.bounds.Contains(pos))
                {
                    player.Shoot();
                }
            }
#endif
        }
    }
}