using UnityEngine;

namespace Lab5Games
{
    public static class UnityExtensions 
    {

        #region Camera
        public static bool CanSee(this Camera camera, Transform target)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
            Vector3 targetPos = target.position;

            foreach(var plane in planes)
            {
                if (plane.GetDistanceToPoint(targetPos) > 0)
                    return false;
            }

            return true;
        }

        public static bool CanSee(this Camera camera , Collider collider)
        {
            return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(camera), collider.bounds);
        }
        #endregion
    }
}
