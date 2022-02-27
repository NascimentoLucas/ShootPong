using System;
using System.Collections;
using UnityEngine;

namespace JungleFrog.Environment
{
    public class Field : MonoBehaviour
    {
        static Field Singleton;

        [Header("Setup.Boundaries")]
        [SerializeField]
        Transform center;

        [Header("GD")]
        [SerializeField]
        float maxDistance = 10;

        private void Awake()
        {
            Singleton = this;
        }

        internal static bool GetOutOfScreen(Vector3 position)
        {
            return Vector3.Distance(Singleton.center.position,
                position) > Singleton.maxDistance;
        }


#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            if (UnityEditor.Selection.Contains(center.gameObject))
            {

                if (center != null)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireSphere(center.position, 0.3f);
                    Gizmos.DrawWireSphere(center.position, maxDistance);
                }
            }
        }
#endif
    }
}