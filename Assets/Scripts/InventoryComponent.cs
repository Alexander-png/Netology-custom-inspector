using Lesson_6_8.Items.Base;
using UnityEngine;

namespace Lesson_6_8
{
    public class InventoryComponent : MonoBehaviour
    {
        [SerializeField]
        private BaseItem[] _items;
        [SerializeField, Range(0f, 10000f)]
        private float _maxInventoryWeight;
    }
}
