using System;
using UnityEngine;

namespace Lesson_6_8.Items.Base
{
    [Serializable]
    public struct ItemInformation
    {
        public string NameId;
        public string DescriptionId;
    }

    public abstract class BaseItem : MonoBehaviour
    {
        [SerializeField]
        private ItemInformation _itemInformation;
    }
}
