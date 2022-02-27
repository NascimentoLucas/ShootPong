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
        Transform min;
        [SerializeField]
        Transform max;
        [SerializeField]
        Transform center;

        [Header("GD")]
        [SerializeField]
        float maxDistance = 10;

        public static Transform Min { get => Singleton.min; }

        public static Transform Max { get => Singleton.max; }


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


            if (min != null && max != null &&
                (UnityEditor.Selection.Contains(min.gameObject)
                || UnityEditor.Selection.Contains(max.gameObject)))
            {


                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(min.position, 0.3f);
                Gizmos.DrawWireSphere(max.position, 0.3f);

                Vector3 start = new Vector3();
                Vector3 end = new Vector3();

                Vector3 vMin = this.min.transform.position;
                Vector3 vMax = this.max.transform.position;

                Gizmos.color = Color.red;
                DrawLine(vMin.x, vMin.y, vMax.x, vMin.y);
                DrawLine(vMax.x, vMin.y, vMax.x, vMax.y);
                DrawLine(vMax.x, vMax.y, vMin.x, vMax.y);
                DrawLine(vMin.x, vMax.y, vMin.x, vMin.y);


                void DrawLine(float minX, float minY, float maxX, float maxY)
                {
                    start.x = minX;
                    start.y = minY;

                    end.x = maxX;
                    end.y = maxY;

                    Gizmos.DrawLine(start, end);
                }
            }
        }
#endif
    }
}