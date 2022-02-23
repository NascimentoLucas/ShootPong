using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JungleFrog.Physics;
using System;

namespace JungleFrog.Missile
{
    public class Missile : PhysicsObject
    {
        [Header("Missile.Setup")]
        [SerializeField]
        Renderer myRenderer;

        [Header("GD")]
        [SerializeField]
        float timeToUnspawn = 2;
        float time;

        [Header("Debug.OnlyShow")]
        [SerializeField]
        bool isMoving;



        public bool IsMoving
        {
            get => isMoving;
            set
            {
                isMoving = value;
                myRenderer.enabled = value;
            }
        }


        private void Awake()
        {
            IsMoving = false;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (PhysicsManager.GetOutOfScreen(transform.position)
                || time < Time.timeSinceLevelLoad)
            {
                Stop();
            }
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