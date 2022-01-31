using UnityEngine;

namespace CustomInput
{
    public static class Input2D
    {
        private static readonly Camera CameraToTrackInput = Camera.main;
        private static readonly Vector2 ScreenMeasure = CameraToTrackInput.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        public static float ScreenValueX => ScreenMeasure.x;
        public static float ScreenValueY => ScreenMeasure.y;

        public static Collider2D Raycast2D()
        {
            if (!Input.GetMouseButtonDown(0)) return null;

            Ray ray = CameraToTrackInput.ScreenPointToRay(Input.mousePosition);
            var raycast = Physics2D.GetRayIntersection(ray);

            return raycast.collider;
        }
    }
}
