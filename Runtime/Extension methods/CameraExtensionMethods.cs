using UnityEngine;

namespace Dacen.ExtensionMethods.Cameras
{
    public static class ExtensionMethods_Cameras
    {
        public static Rect OrthographicBoundsInWorldSpace(this Camera camera)
        {
            if (!camera.orthographic)
            {
                Debug.LogError($"{camera.name} has to be orthographic!");
                return new Rect();
            }
            Vector2 bottomLeft = camera.ViewportToWorldPoint(Vector3.zero);
            Vector2 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, 0));
            return new Rect(bottomLeft, new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y));
        }

        //public static Rect GetBoundsInWorldSpace(this PixelPerfectCamera ppCamera, int pixelsPerUnit)
        //{
        //    Vector2 size = new Vector2((float)ppCamera.refResolutionX / pixelsPerUnit, (float)ppCamera.refResolutionY / pixelsPerUnit);
        //    Vector2 minPosition = (Vector2)ppCamera.transform.position - size / 2;
        //    return new Rect(minPosition, size);
        //}
    }
}