using UnityEditor;
using UnityEditor.UI;

namespace Lab5Games.UI.Ediotr
{

    [CustomEditor(typeof(UI.NoDrawingGraphic))]
    public class NoDrawingGraphicEditor : GraphicEditor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            base.RaycastControlsGUI();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
