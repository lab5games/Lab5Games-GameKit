using UnityEngine;
using UnityEngine.UI;

namespace Lab5Games.UI
{
    [RequireComponent(typeof(CanvasRenderer))]
    public class NoDrawingGraphic : Graphic
    {
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
        }
    }
}
