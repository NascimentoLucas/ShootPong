using System.Collections;
using UnityEngine;
using JungleFrog.Missile;
using System;

namespace JungleFrog.Cannon
{
    public class Cannon : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        SpriteRenderer spriteRenderer;
        [SerializeField]
        Transform edge;
        [SerializeField]
        Missile.Missile missile;

        [Header("GD")]
        [SerializeField]
        Color readyToShootColor = Color.green;
        [SerializeField]
        Color waitingToShootColor = Color.red;

        private void Awake()
        {
            missile.gameObject.transform.parent = null;
        }

        public bool Shoot()
        {
            if (!missile.IsMoving)
            {
                missile.transform.position = edge.position;
                Vector3 dir = edge.position - transform.position;
                missile.Move(dir.normalized);
                return true;
            }

            return false;
        }


#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (edge == null) return;

            Gizmos.color = Color.red;
            Vector3 dir = edge.position - transform.position;

            Gizmos.DrawWireSphere(edge.position, 0.1f);

            Gizmos.DrawLine(transform.position,
                transform.position + dir);
        }
#endif

        internal void MissleCanShoot(bool value)
        {
            if (value)
                spriteRenderer.color = readyToShootColor;
            else
                spriteRenderer.color = waitingToShootColor;
        }
    }
}