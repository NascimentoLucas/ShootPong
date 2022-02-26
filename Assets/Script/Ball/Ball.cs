using System.Collections;
using UnityEngine;
using JungleFrog.Physics;
using System;

namespace JungleFrog.Ball
{
    public class Ball : PhysicsObject
    {
        [Header("GD")]
        [SerializeField]
        [Range(0.0001f, 0.999f)]
        float gravity = 0.1f;



        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            Direction *= gravity;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Missile.Missile missile = collision.GetComponent<Missile.Missile>();
            if (missile != null)
            {
                Vector2 dir = transform.position - missile.transform.position;
                Move(dir.normalized);
            }
        }
    }
}