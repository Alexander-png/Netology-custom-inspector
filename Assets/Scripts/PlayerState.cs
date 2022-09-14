using Lesson_6_8.Enums;
using UnityEngine;

namespace Lesson_6_8
{
    public class PlayerState : MonoBehaviour
    {
        [SerializeField]
        private CharacterClass _characterType;

        [SerializeField]
        private SwordPlaceHolder[] _items;

        [SerializeField, Range(0f, 10000f)]
        private float _maxInventoryWeight;
    }
}
