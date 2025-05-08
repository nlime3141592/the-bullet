using UnityEditor;
using UnityEditor.UI;

namespace Unchord
{
    [CustomEditor(typeof(UICarouselButton))]
    public class UICarouselButtonEditor : ButtonEditor
    {
        private SerializedProperty _direction;

        protected override void OnEnable()
        {
            base.OnEnable();

            _direction = serializedObject.FindProperty("direction");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();

            EditorGUILayout.PropertyField(_direction);

            serializedObject.ApplyModifiedProperties();
        }
    }
}