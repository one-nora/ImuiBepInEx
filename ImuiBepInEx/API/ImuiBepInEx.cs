using UnityEngine;

namespace ImuiBepInEx.API
{
    public static class ImuiBepInExAPI
    {
        public static ImuiPanel CreateImuiPanel<T>() where T : MonoBehaviour
        {
            var canvas = Utility.CreateCanvas();
            if (canvas == null)
                return null;

            var backend = Utility.CreateImuiPanel(canvas.transform);
            if (backend == null)
                return null;
            
            backend.gameObject.AddComponent<T>();
            
            return new ImuiPanel(canvas, backend);
        }
    }
}
