using Lesson_6_8.Enums;
using Lesson_6_8.Items.Base;
using UnityEngine;

namespace Lesson_6_8
{
    public class SwordPlaceHolder : BaseItem
    {
        [SerializeField]
        private WeaponStyle _weaponStyle;
        [SerializeField]
        private float _attack;
        [SerializeField, Range(0f, 100f)]
        private float _weight;
    }
}
