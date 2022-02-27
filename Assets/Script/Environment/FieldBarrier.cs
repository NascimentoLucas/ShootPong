using System.Collections;
using UnityEngine;

namespace JungleFrog.Environment
{
    public class FieldBarrier : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            Debug.Log(other.name);
        }
    }
}