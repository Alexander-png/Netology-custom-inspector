using UnityEngine;

namespace Lesson_6_8
{
    public class AttackComponent : MonoBehaviour
    {
        [SerializeField]
        private Animator _attackAnimator;
        [SerializeField]
        private SwordPlaceHolder _currentWeapon;
        [SerializeField]
        private float _attackSpeed;
        [SerializeField]
        private bool _isAttacking;
        [SerializeField]
        private Color _attackFlashColor;
    }
}
