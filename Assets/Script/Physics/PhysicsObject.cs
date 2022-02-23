using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JungleFrog.Physics
{
    public abstract class PhysicsObject : MonoBehaviour
    {
        [Header("GD")]
        [SerializeField]
        float speed = 0.1f;


        [Header("Debug.OnlyShow")]
        [SerializeField]
        Vector3 direction;

        protected virtual void FixedUpdate()
        {
            transform.position += direction;
            CheckBoundaries();
        }

        private void CheckBoundaries()
        {

            if (transform.position.x < PhysicsManager.Min.position.x)
            {
                SetXPos(PhysicsManager.Min.position.x);
            }
            else if (transform.position.x > PhysicsManager.Max.position.x)
            {
                SetXPos(PhysicsManager.Max.position.x);
            }

            void SetXPos(float x)
            {
                Vector3 pos = transform.position;
                pos.x = x;
                direction.x *= -1;
                transform.position = pos;
            }
        }

        internal virtual void Stop()
        {
            direction = Vector3.zero;
        }

        internal virtual void Move(Vector3 dir)
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