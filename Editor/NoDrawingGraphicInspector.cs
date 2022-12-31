using UnityEditor;
using UnityEditor.UI;

namespace Lab5Games.Ediotr
{

    [CustomEditor(typeof(UI.NoDrawingGraphic))]
    public class NoDrawingGraphicInspector : GraphicEditor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            base.RaycastControlsGUI();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
