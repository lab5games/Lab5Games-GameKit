using UnityEngine;

namespace Lab5Games.Mathematics
{
    /// <summary>
    /// https://www.gamedeveloper.com/business/how-to-work-with-bezier-curve-in-games-with-unity
    /// </summary>
    public static class BezierCurve
    {
        /// <summary>
        /// Linear Bezier curve has two control points. For given two points P0 and P1, a Linear Bezier curve is simply a straight line between those two points.
        /// </summary>
        public static Vector3 Linear(Vector3 p0, Vector3 p1, float t)
        {
            return p0 + t * (p1 - p0);
        }

        /// <summary>
        /// Quadratic bezier curve has three control points. Quadratic Bezier curve is a point-to-point linear interpolation of two Linear Bezier Curves. 
        /// </summary>
        public static Vector3 Quadratic(Vector3 p0, Vector3 p1, Vector3 p2, float t)
        {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;

            return (uu * p0) + (2 * u * t * p1) + (tt * p2);
        }

        /// <summary>
        /// Cubic Bezier curve has four control points. Quadratic bezier curve is a point-to-point linear interpolation of two Quadratic Bezier curves. 
        /// </summary>
        public static Vector3 Cubic(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            float u = 1 - t;
            float tt = t * t;
            float uu = u * u;
            float ttt = t * t * t;
            float uuu = u * u * u;

            return (uuu * p0) + (3 * uu * t * p1) + (3 * u * tt * p2) + (ttt * p3);
        }
    }
}
