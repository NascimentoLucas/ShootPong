using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JungleFrog.Environment;

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

        protected Vector3 Direction { get => direction; set => direction = value; }

        protected virtual void FixedUpdate()
        {
            transform.position += direction;
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            FieldBarrier fieldBarrier = collision.GetComponent<FieldBarrier>();
            if (fieldBarrier != null)
            {
                direction.x *= -1;
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