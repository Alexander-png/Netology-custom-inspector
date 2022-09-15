using System.Text;
using UnityEngine;

namespace Lesson_6_8.EditorExtentions.Windows.EditorWindowConfigurations
{
    public static class CustomInspectorConfig
    {
        private const int _separatorWidth = 40;
        public const string WindowName = "Custom inspector";
        public const string PathInEditor = "Extensions/Windows/References Inspector #c";
        public const float SpacingBetweenComponents = 10f;
        public const float HeaderPlaceHeight = 30f;

        private static readonly string SeparatorPattern = "_____";
        private static string _separator;
        public static readonly Rect DefaultPosition = new Rect(1648f, 73.6f, 399f, 998f);
        
        public static readonly GUIStyle BigLabelHeaderStyle = new GUIStyle("label")
        {
            fontSize = 20,
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter
        };

        public static readonly GUIStyle SmallLabelHeaderStyle = new GUIStyle("label")
        {
            fontSize = 15,
            fontStyle = FontStyle.Italic,
            alignment = TextAnchor.MiddleCenter
        };

        public static string Separator
        {
            get
            {
                if (string.IsNullOrEmpty(_separator))
                {
                    var strs = new StringBuilder();
                    for (int i = 0; i < _separatorWidth; i++)
                        strs.Append(SeparatorPattern);
                    _separator = strs.ToString();
                }
                return _separator;
            }
        }
    }
}
