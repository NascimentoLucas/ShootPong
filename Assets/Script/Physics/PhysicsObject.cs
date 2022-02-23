using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JungleFrog.Physics
{
    public abstract class PhysicsObject : MonoBehaviour
    {

        [Header("Setup")]
        [SerializeField]
        PhysicsManager manager;

        [Header("GD")]
        [SerializeField]
        float speed = 0.1f;


        [Header("Debug.OnlyShow")]
        [SerializeField]
        Vector3 direction;

        private void FixedUpdate()
        {
            transform.position += direction;
            CheckBoundaries();
        }

        private void CheckBoundaries()
        {
            Vector3 pos = transform.position;

            if (transform.position.x < manager.Min.position.x)
            {
                pos.x = manager.Min.position.x;
                direction = Vector3.zero;
            }
            else if (transform.position.x > manager.Max.position.x)
            {
                pos.x = manager.Max.position.x;
                direction = Vector3.zero;
            }

            if (transform.position.y < manager.Min.position.y)
            {
                pos.y = manager.Min.position.y;
                direction = Vector3.zero;
            }
            else if (transform.position.y > manager.Max.position.y)
            {
                pos.y = manager.Max.position.y;
                direction = Vector3.zero;
            }

            transform.position = pos;
        }

        internal void Move(Vector3 dir)
        {
            dir.z = 0;
            dir *= speed;
            direction += dir;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, transform.position + (direction * 5));
        }
#endif
    }
}