using Lesson_6_8.EditorExtentions.Windows.EditorWindowConfigurations;
using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace Lesson_6_8.EditorExtentions.Windows
{
	public class CustomInspector : EditorWindow
	{
		private readonly BindingFlags _flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

		private static Type _customInspector;
		private static Type _inspectorWindow;
		private SerializedObject _currentSerializedComponent;
		private Vector2 _currentScrollPosition;

		[MenuItem(CustomInspectorConfig.PathInEditor, priority = 1)]
		public static CustomInspector ShowReferencesInspectorEditor()
		{
			var window = GetWindow<CustomInspector>(false, CustomInspectorConfig.WindowName, true);
			window.position = CustomInspectorConfig.DefaultPosition;
			return window;
		}

		[Shortcut("CustomInspector", KeyCode.X, ShortcutModifiers.Shift)]
		public static void FocusCustomInspector()
		{
			if (_customInspector == null) _customInspector = typeof(CustomInspector);
			FocusWindowIfItsOpen(_customInspector);
		}

		[Shortcut("Inspector", KeyCode.Z, ShortcutModifiers.Shift)]
		public static void FocusInspectorWindow()
		{
			if (_inspectorWindow == null)
				_inspectorWindow = AppDomain.CurrentDomain.Load("UnityEditor").GetType("UnityEditor.InspectorWindow");

			FocusWindowIfItsOpen(_inspectorWindow);
		}

        public void OnEnable()
		{
			Selection.selectionChanged += Repaint;
		}

		public void OnDisable()
		{
			Selection.selectionChanged -= Repaint;
		}

        public void OnDestroy()
        {
			_customInspector = null;
			_inspectorWindow = null;
		}

        private void OnGUI()
		{
			DrawSelectedGameObjects();
		}

		private void DrawSelectedGameObjects()
        {
			_currentScrollPosition = EditorGUILayout.BeginScrollView(_currentScrollPosition);

			foreach (var obj in Selection.gameObjects)
			{
				PrintGameObject(obj);
			}
			EditorGUILayout.EndScrollView();
		}

		private void PrintGameObject(GameObject obj)
        {
			var components = obj.GetComponents<MonoBehaviour>();
			if (components.Length == 0) return;

			PrintHeader(obj.name, true);
			PrintComponents(components);
		}

		private void PrintComponents(MonoBehaviour[] components)
        {
			foreach (var comp in components)
			{
				_currentSerializedComponent = new SerializedObject(comp);
				_currentSerializedComponent.Update();

				EditorGUILayout.Space(CustomInspectorConfig.SpacingBetweenComponents);
				PrintComponent(comp);

				if (GUI.changed) EditorUtility.SetDirty(comp);
				_currentSerializedComponent.ApplyModifiedProperties();
			}
		}

		private void PrintComponent(MonoBehaviour component)
		{
            Type componentType = component.GetType();

			PrintHeader(componentType.Name, false);
			PrintComponentFields(componentType.GetFields(_flags));
		}

		private void PrintHeader(string text, bool isGameObjectHeader)
		{
			EditorGUILayout.LabelField(CustomInspectorConfig.Separator);
			var style = isGameObjectHeader ? CustomInspectorConfig.BigLabelHeaderStyle : CustomInspectorConfig.SmallLabelHeaderStyle;
			EditorGUILayout.LabelField(text, style, GUILayout.ExpandWidth(true), GUILayout.Height(CustomInspectorConfig.HeaderPlaceHeight));
		}

		private void PrintComponentFields(FieldInfo[] fieldsToPrint)
        {
			EditorGUILayout.BeginVertical("box");

			foreach (var field in fieldsToPrint)
			{
				if (field.IsPrivate && field.GetCustomAttributes(typeof(SerializeField), false).Length == 0)
					continue;
				PrintField(field);
			}
			EditorGUILayout.EndVertical();
		}

		private void PrintField(FieldInfo field)
		{
			EditorGUILayout.BeginHorizontal();
            SerializedProperty property = _currentSerializedComponent.FindProperty(field.Name);
			EditorGUILayout.PropertyField(property);
			EditorGUILayout.EndHorizontal();
		}
	}
}