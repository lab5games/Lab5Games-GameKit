using UnityEngine;
using UnityEngine.UI;

namespace Lab5Games.UI
{
    [AddComponentMenu("UI/Lab5Games UI/No Drawing Graphic")]
    [RequireComponent(typeof(CanvasRenderer))]
    public class NoDrawingGraphic : Graphic
    {
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
        }
    }
}
