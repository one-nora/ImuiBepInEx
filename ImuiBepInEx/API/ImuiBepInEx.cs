using UnityEngine;

namespace ImuiBepInEx.API
{
    public static class ImuiBepInExAPI
    {
        public static ImuiPanel CreateImuiPanel()
        {
            var canvas = Utility.CreateCanvas();
            if (canvas == null)
                return null;

            var backend = Utility.CreateImuiPanel(canvas.transform);
            if (backend == null)
                return null;
            
            return new ImuiPanel(canvas, backend);
        }
    }
}
