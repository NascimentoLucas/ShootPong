using System.Collections;
using UnityEngine;
using JungleFrog.Missile;

namespace JungleFrog.Cannon
{
    public class Cannon : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        Transform edge;
        [SerializeField]
        Missile.Missile missile;

        private void Awake()
        {
            missile.gameObject.transform.parent = null;
        }

        public void Shoot()
        {
            if (!missile.IsMoving)
            {
                missile.transform.position = edge.position;
                Vector3 dir = edge.position - transform.position;
                missile.Move(dir.normalized); 
            }
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
    }
}