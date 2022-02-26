using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JungleFrog.Physics;
using JungleFrog.Environment;
using System;

namespace JungleFrog.Missile
{
    public class Missile : PhysicsObject
    {

        [Header("Setup")]
        [SerializeField]
        SpriteRenderer spriteRenderer;
        [SerializeField]
        Cannon.Cannon cannon;
        Ball.Ball ball;

        [Header("GD")]
        [SerializeField]
        float timeToUnspawn = 2;
        float time;

        [Header("Debug.OnlyShow")]
        [SerializeField]
        bool isMoving;

        private void Start()
        {
            ball = FindObjectOfType<Ball.Ball>();
        }

        public bool IsMoving
        {
            get => isMoving;
            set
            {
                isMoving = value;
                cannon.MissleCanShoot(!value);
                gameObject.SetActive(value);
            }
        }


        private void Awake()
        {
            IsMoving = false;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (Field.GetOutOfScreen(transform.position)
                || time < Time.timeSinceLevelLoad)
            {
                Stop();
            }

            RotateSprite();
        }

        private void RotateSprite()
        {
            //https://answers.unity.com/questions/585035/lookat-2d-equivalent-.html
            float rot_z = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }

        internal override void Stop()
        {
            base.Stop();
            IsMoving = false;
        }

        internal override void Move(Vector3 dir)
        {
            IsMoving = true;
            time = timeToUnspawn + Time.timeSinceLevelLoad;
            base.Move(dir);
        }
    }

}