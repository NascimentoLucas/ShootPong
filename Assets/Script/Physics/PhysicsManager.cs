using System.Collections;
using UnityEngine;

namespace JungleFrog.Physics
{
    public class PhysicsManager : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        PhysicsObject physicsObject;

        [Header("Setup.Boundaries")]
        [SerializeField]
        Transform min;
        [SerializeField]
        Transform max;

        Vector3 lastMousePosition;
        Vector3 direction;

        public Transform Min { get => min; }
        public Transform Max { get => max; }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                direction = (lastMousePosition
                    - physicsObject.transform.position).normalized;

                physicsObject.Move(direction);
            }
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(lastMousePosition, 0.3f);

            if (Min == null || Max == null) return;

            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(Min.position, 0.3f);
            Gizmos.DrawWireSphere(Max.position, 0.3f);

            Vector3 start = new Vector3();
            Vector3 end = new Vector3();

            Vector3 min = Min.transform.position;
            Vector3 max = Max.transform.position;

            Gizmos.color = Color.red;
            DrawLine(min.x, min.y, max.x, min.y);
            DrawLine(max.x, min.y, max.x, max.y);
            DrawLine(max.x, max.y, min.x, max.y);
            DrawLine(min.x, max.y, min.x, min.y);


            void DrawLine(float minX, float minY, float maxX, float maxY)
            {
                start.x = minX;
                start.y = minY;

                end.x = maxX;
                end.y = maxY;

                Gizmos.DrawLine(start, end);
            }
        }
#endif
    }
}