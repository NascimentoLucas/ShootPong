using System;
using UnityEngine;
using JungleFrog.Physics;
using JungleFrog.Audio;

namespace JungleFrog.Ball
{
    public class Ball : PhysicsObject
    {
        const string TouchedTrigger = "Touched";

        [Header("Ball.Setup")]
        [SerializeField]
        Animator animator;
        [SerializeField]
        ParticleSystem particleSystem;

        [Header("GD")]
        [SerializeField]
        [Range(0.0001f, 0.999f)]
        float gravity = 0.1f;

        Vector3 startPositon;

        private void Awake()
        {
            startPositon = transform.position;
        }

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
                missile.Stop();
                
                animator.SetTrigger(TouchedTrigger);
                particleSystem.Play();
                AudioManager.Play(SoundEffect.BallTouched);
            }
        }

        internal void ResetPosition()
        {
            Direction = Vector3.zero;
            transform.position = startPositon;
        }
    }
}