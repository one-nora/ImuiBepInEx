using UnityEngine;

namespace ImuiBepInEx.API
{
    public static class ImuiBepInExAPI
    {
        public static T CreateImuiPanel<T>() where T : MonoBehaviour
        {
            var canvas = Utility.CreateCanvasObject();
            if (canvas == null)
                return null;

            var backend = Utility.CreateImuiPanel(canvas.transform);
            if (backend == null)
                return null;

            return backend.gameObject.AddComponent<T>();
        }
    }
}
