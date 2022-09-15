using Lesson_6_8.Enums;
using UnityEngine;

namespace Lesson_6_8
{
    public class PlayerState : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _targetCameraPosition;

        [SerializeField]
        private CharacterClass _characterType;
        
        [SerializeField]
        private AttackComponent _attackComponent;
        [SerializeField]
        private InventoryComponent _inventory;

        public Side CharacterSide;
    }
}
