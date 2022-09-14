using UnityEngine;

namespace Lesson_6_8
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField, Range(0, 50f)]
        private float moveSpeed;
    }
}
